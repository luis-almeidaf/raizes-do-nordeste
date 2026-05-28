using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Enums;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Domain.Repositories.Produto;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoCommandHandler(
    IPedidoWriteOnlyRepository pedidoRepo,
    IProdutoReadOnlyRepository produtoRepo,
    IUnitOfWork unitOfWork,
    IUsuarioContexto usuarioContexto) : IRequestHandler<ProcessarPagamentoCommand, ProcessarPagamentoResponse>
{
    public async Task<ProcessarPagamentoResponse> Handle(ProcessarPagamentoCommand request,
        CancellationToken cancellationToken)
    {
        ValidarRequest(request);

        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();
        var pedido = await BuscarPedido(request.PedidoId, usuario.Id);

        var pagamentoAprovado = ProcessarStatusDoPagamento(request.StatusPagamento, pedido);
        if (!pagamentoAprovado)
            return await RecusarPagamento(pedido);

        await AtualizarEstoque(pedido);
        pedidoRepo.AtualizarPedido(pedido);
        await unitOfWork.Commit();

        return ProcessarPagamentoResponse.Criar(pedido.Id, "Pagamento aprovado");
    }

    private static void ValidarRequest(ProcessarPagamentoCommand request)
    {
        var resultado = new ProcessarPagamentoValidator().Validate(request);

        if (resultado.IsValid) return;

        var erros = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
        throw new ErroDeValidacaoException(erros);
    }

    private async Task<Pedido> BuscarPedido(int pedidoId, Guid usuarioId)
    {
        var pedido = await pedidoRepo.BuscarPorId(pedidoId);
        if (pedido is null)
            throw new PedidoNaoEncontradoException();

        return !pedido.PertenceAoUsuarioLogado(usuarioId) ? throw new PedidoNaoPertenceAoUsuarioException() : pedido;
    }

    private static bool ProcessarStatusDoPagamento(StatusPagamento statusPagamentoRequest, Pedido pedido)
    {
        if (pedido.Status != Status.AguardandoPagamento && pedido.Status != Status.PagamentoFalhou)
            throw new PagamentoNaoPodeSerProcessadoException();

        if (statusPagamentoRequest == StatusPagamento.MockRecusado)
        {
            pedido.AtualizarStatus(Status.PagamentoFalhou);
            return false;
        }

        pedido.AtualizarStatus(Status.Pago);
        return true;
    }

    private async Task<ProcessarPagamentoResponse> RecusarPagamento(Pedido pedido)
    {
        pedidoRepo.AtualizarPedido(pedido);
        await unitOfWork.Commit();
        return ProcessarPagamentoResponse.Criar(pedido.Id, "Pagamento recusado");
    }

    private async Task AtualizarEstoque(Pedido pedido)
    {
        var produtosId = pedido.ItensPedido.Select(item => item.ProdutoId).ToList();
        var produtosNoEstoque = await produtoRepo.BuscarProdutosNoEstoque(produtosId, pedido.UnidadeId);
        var quantidades = pedido.ItensPedido.ToDictionary(item => item.ProdutoId, item => item.Quantidade);

        DecrementarQuantidadesNoEstoque(produtosNoEstoque, quantidades);
    }

    private static void DecrementarQuantidadesNoEstoque(List<ItemEstoque> produtosNoEstoque,
        Dictionary<int, int> quantidadesDeProdutosDoPedido)
    {
        foreach (var produtoNoEstoque in produtosNoEstoque)
        {
            var quantidadeSolicitada = quantidadesDeProdutosDoPedido[produtoNoEstoque.ProdutoId];

            if (!produtoNoEstoque.DiminuirQuantidade(quantidadeSolicitada))
                throw new EstoqueInsuficienteException(produtoNoEstoque.Produto.Id);
        }
    }
}
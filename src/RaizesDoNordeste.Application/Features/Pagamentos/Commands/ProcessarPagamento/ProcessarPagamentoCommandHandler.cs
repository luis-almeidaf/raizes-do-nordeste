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
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var pedido = await pedidoRepo.BuscarPorId(request.PedidoId, usuario.Id);
        if (pedido is null) throw new PedidoNaoEncontradoException();

        var produtosId = new List<int>(pedido.ItensPedido.Count);
        produtosId.AddRange(pedido.ItensPedido.Select(item => item.ProdutoId));

        var produtosNoEstoque = await produtoRepo.BuscarProdutosNoEstoque(produtosId, pedido.UnidadeId);
        var quantidadesDeProdutosDoPedido =
            pedido.ItensPedido.ToDictionary(item => item.ProdutoId, item => item.Quantidade);

        var pagamentoAprovado = ProcessarStatusDoPagamento(request.FormaDePagamento, pedido);
        if (!pagamentoAprovado)
            return ProcessarPagamentoResponse.Criar(pedido.Id, "Pagamento recusado");

        DecrementarQuantidadesNoEstoque(produtosNoEstoque, quantidadesDeProdutosDoPedido);
        pedidoRepo.AtualizarPedido(pedido);
        await unitOfWork.Commit();

        return ProcessarPagamentoResponse.Criar(pedido.Id, "Pagamento aprovado");
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

    private static bool ProcessarStatusDoPagamento(
        FormaDePagamento formaDePagamentoRequest, Pedido pedido)
    {
        if (pedido.Status != Status.AguardandoPagamento && pedido.Status != Status.PagamentoFalhou)
            throw new PagamentoNaoPodeSerProcessadoException();

        if (formaDePagamentoRequest == FormaDePagamento.MockRecusado)
        {
            pedido.AtualizarStatus(Status.PagamentoFalhou);
            return false;
        }

        pedido.AtualizarStatus(Status.Pago);
        return true;
    }
}
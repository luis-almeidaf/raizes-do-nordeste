using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Domain.Repositories.Produto;
using RaizesDoNordeste.Domain.Repositories.Unidade;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;

public class CriarPedidoCommandHandler(
    IUnitOfWork unitOfWork,
    IUsuarioContexto usuarioContexto,
    IPedidoWriteOnlyRepository pedidoRepo,
    IProdutoReadOnlyRepository produtoRepo,
    IUnidadeReadOnlyRepository unidadeRepo) : IRequestHandler<CriarPedidoCommand, CriarPedidoResponse>
{
    public async Task<CriarPedidoResponse> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
    {
        var unidade = await unidadeRepo.BuscarUnidadePorId(request.UnidadeId);
        if (unidade == null) throw new UnidadeNaoEncontradaException();

        ValidarRequest(request);

        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var itensDaRequest = request.ItensPedido;
        var produtosId = ListarProdutosId(itensDaRequest);
        var produtosNoEstoque = await produtoRepo.BuscarProdutosNoEstoque(produtosId, request.UnidadeId);
        var produtosEncontrados = produtosNoEstoque.Select(p => p.ProdutoId).ToList();
        ValidarSeProdutoExisteNoEstoque(produtosId, produtosEncontrados);

        var quantidadesDaRequest = itensDaRequest.ToDictionary(item => item.ProdutoId, item => item.Quantidade);
        ValidarQuantidadesNoEstoque(produtosNoEstoque, quantidadesDaRequest);

        var valorTotal = CalcularValorTotalDoPedido(produtosNoEstoque, quantidadesDaRequest);
        var itensPedido = CriarItensPedido(itensDaRequest);

        var pedido = Pedido.Criar(usuario.Id, request.UnidadeId, request.CanalPedido, request.FormaDePagamento,
            valorTotal);
        pedido.AdicionarItens(itensPedido);

        await pedidoRepo.Salvar(pedido);
        await unitOfWork.Commit();
        return CriarPedidoResponse.Criar(pedido.Id, pedido.ClienteId, pedido.UnidadeId, pedido.ValorTotal);
    }

    private static List<int> ListarProdutosId(List<ItemPedidoRequest> itensDaRequest)
    {
        var produtosId = new List<int>(itensDaRequest.Count);
        produtosId.AddRange(itensDaRequest.Select(item => item.ProdutoId));
        return produtosId;
    }

    private static void ValidarSeProdutoExisteNoEstoque(List<int> produtosId, List<int> produtosEncontrados)
    {
        foreach (var produtoId in produtosId)
            if (!produtosEncontrados.Contains(produtoId))
                throw new ProdutoNaoDisponivelEmEstoque(produtoId);
    }

    private static void ValidarQuantidadesNoEstoque(List<ItemEstoque> produtosNoEstoque,
        Dictionary<int, int> quantidadesPorProduto)
    {
        foreach (var produtoNoEstoque in produtosNoEstoque)
        {
            var quantidadeSolicitada = quantidadesPorProduto[produtoNoEstoque.ProdutoId];

            if (quantidadeSolicitada > produtoNoEstoque.Quantidade)
                throw new EstoqueInsuficienteException(produtoNoEstoque.Produto.Id);
        }
    }

    private static decimal CalcularValorTotalDoPedido(List<ItemEstoque> produtosNoEstoque,
        Dictionary<int, int> quantidadesDaRequest)
    {
        decimal valorTotal = 0;
        foreach (var produtoNoEstoque in produtosNoEstoque)
        {
            var quantidadeSolicitada = quantidadesDaRequest[produtoNoEstoque.ProdutoId];
            var precoDoProduto = produtoNoEstoque.Produto.Preco;
            valorTotal += precoDoProduto * quantidadeSolicitada;
        }

        return valorTotal;
    }

    private static List<ItemPedido> CriarItensPedido(List<ItemPedidoRequest> itensDaRequest)
    {
        return itensDaRequest.Select(item => ItemPedido.Criar(item.ProdutoId, item.Quantidade)).ToList();
    }

    private static void ValidarRequest(CriarPedidoCommand request)
    {
        var resultado = new CriarPedidoValidator().Validate(request);

        if (resultado.IsValid) return;

        var erros = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
        throw new ErroDeValidacaoException(erros);
    }
}
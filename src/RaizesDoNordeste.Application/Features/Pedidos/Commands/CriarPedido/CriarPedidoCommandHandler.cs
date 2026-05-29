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
        ValidarRequest(request);
        await BuscarUnidade(request.UnidadeId);
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var produtosId = request.ItensPedido.Select(item => item.ProdutoId).ToList();
        var produtosNoEstoque = await produtoRepo.BuscarProdutosNoEstoque(produtosId, request.UnidadeId);
        ValidarSeProdutoExisteNoEstoque(produtosId, produtosNoEstoque);

        var quantidadesDaRequest = request.ItensPedido.ToDictionary(item => item.ProdutoId, item => item.Quantidade);
        ValidarQuantidadesNoEstoque(produtosNoEstoque, quantidadesDaRequest);

        var itensPedido = CriarItensPedido(request.ItensPedido, produtosNoEstoque);

        var pedido = Pedido.Criar(usuario.Id, request.UnidadeId, request.CanalPedido, request.FormaDePagamento);
        pedido.AdicionarItens(itensPedido);
        pedido.CalcularValorTotal();

        await pedidoRepo.Salvar(pedido);
        await unitOfWork.Commit();

        return CriarPedidoResponse.Criar(pedido.Id, pedido.ClienteId, pedido.UnidadeId, pedido.ValorTotal);
    }

    private static void ValidarRequest(CriarPedidoCommand request)
    {
        var resultado = new CriarPedidoValidator().Validate(request);

        if (resultado.IsValid) return;

        var erros = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
        throw new ErroDeValidacaoException(erros);
    }

    private async Task BuscarUnidade(int unidadeId)
    {
        if (await unidadeRepo.BuscarUnidadePorId(unidadeId) == null)
            throw new UnidadeNaoEncontradaException();
    }


    private static void ValidarSeProdutoExisteNoEstoque(List<int> produtosId, List<ItemEstoque> produtosNoEstoque)
    {
        var idDosProdutosEncontrados = produtosNoEstoque.Select(p => p.ProdutoId).ToList();

        foreach (var produtoId in produtosId)
            if (!idDosProdutosEncontrados.Contains(produtoId))
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

    private static List<ItemPedido> CriarItensPedido(List<ItemPedidoRequest> itensDaRequest,
        List<ItemEstoque> itensEstoque)
    {
        var itensPedido = new List<ItemPedido>();

        foreach (var itemRequest in itensDaRequest)
        {
            var itemEstoque = itensEstoque.First(ie => ie.ProdutoId == itemRequest.ProdutoId);
            itensPedido.Add(ItemPedido.Criar(itemRequest.ProdutoId, itemEstoque.Produto.Preco, itemRequest.Quantidade));
        }

        return itensPedido;
    }
}
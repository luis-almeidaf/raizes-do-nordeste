using MediatR;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio.Response;
using RaizesDoNordeste.Domain.Repositories.Unidade;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;

public class BuscarCardapioQueryHandler(IUnidadeReadOnlyRepository repository)
    : IRequestHandler<BuscarCardapioQuery, BuscarCardapioResponse>
{
    public async Task<BuscarCardapioResponse> Handle(BuscarCardapioQuery request, CancellationToken cancellationToken)
    {
        var unidade = await repository.BuscarUnidadePorId(request.UnidadeId);
        if (unidade == null) throw new UnidadeNaoEncontradaException();

        var itensEstoque = await repository.BuscarItensEstoque(request.UnidadeId);
        var unidadeNome = unidade.Nome;
        var cardapio = new List<ItemCardapioResponse>(itensEstoque.Count);

        cardapio.AddRange(itensEstoque.Select(item =>
            ItemCardapioResponse.Criar(item.ProdutoId, item.Produto.Nome, item.Produto.Descricao, item.Produto.Preco)));

        return BuscarCardapioResponse.Criar(request.UnidadeId, unidadeNome, cardapio);
    }
}
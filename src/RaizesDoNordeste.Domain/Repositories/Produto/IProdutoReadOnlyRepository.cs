namespace RaizesDoNordeste.Domain.Repositories.Produto;

public interface IProdutoReadOnlyRepository
{
    Task<List<Entities.ItemEstoque>> BuscarProdutosNoEstoque(List<int> produtosIds, int unidadeId);
}
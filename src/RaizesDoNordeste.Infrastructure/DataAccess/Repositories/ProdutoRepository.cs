using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Produto;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class ProdutoRepository(RaizesDoNordesteDbContext dbContext) : IProdutoReadOnlyRepository
{
    public async Task<List<ItemEstoque>> BuscarProdutosNoEstoque(List<int> produtosIds, int unidadeId) => await dbContext.ItensEstoque
        .Where(ie => produtosIds.Contains(ie.ProdutoId) && ie.Estoque.UnidadeId == unidadeId)
        .Include(ie => ie.Produto)
        .ToListAsync();
}
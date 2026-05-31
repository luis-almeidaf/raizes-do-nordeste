using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Unidade;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class UnidadeRepository(RaizesDoNordesteDbContext dbContext) : IUnidadeReadOnlyRepository
{
    public Task<List<Unidade>> BuscarUnidades() => dbContext.Unidade.AsNoTracking().ToListAsync();

    public Task<Unidade?> BuscarUnidadePorId(int unidadeId) =>
        dbContext.Unidade.AsNoTracking().FirstOrDefaultAsync(u => u.Id == unidadeId);

    public Task<List<ItemEstoque>> BuscarItensEstoque(int unidadeId)
    {
        return dbContext.ItensEstoque
            .Where(item => item.Estoque.UnidadeId == unidadeId && item.Quantidade > 0)
            .Include(item => item.Produto)
            .OrderBy(item => item.ProdutoId)
            .ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Unidade;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class UnidadeRepository(RaizesDoNordesteDbContext dbContext) : IUnidadeReadOnlyRepository
{
    public Task<List<Unidade>> BuscarUnidades() => dbContext.Unidade.AsNoTracking().ToListAsync();
}
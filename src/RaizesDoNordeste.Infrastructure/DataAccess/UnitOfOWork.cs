using RaizesDoNordeste.Domain.Repositories;

namespace RaizesDoNordeste.Infrastructure.DataAccess;

public class UnitOfOWork(RaizesDoNordesteDbContext context) : IUnitOfWork
{
    public  async Task Commit() => await context.SaveChangesAsync();
}
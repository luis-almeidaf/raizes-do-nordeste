using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Auditoria;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class AuditoriaRepository(RaizesDoNordesteDbContext dbContext) : IAuditoriaRepository
{
    public async Task Salvar(Auditoria auditoria) => await dbContext.Auditoria.AddAsync(auditoria);
}
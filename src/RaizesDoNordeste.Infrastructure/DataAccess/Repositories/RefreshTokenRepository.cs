using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class RefreshTokenRepository(RaizesDoNordesteDbContext dbContext) : IRefreshTokenWriteOnlyRepository
{
    public async Task Salvar(RefreshToken refreshToken) => await dbContext.AddAsync(refreshToken);
}
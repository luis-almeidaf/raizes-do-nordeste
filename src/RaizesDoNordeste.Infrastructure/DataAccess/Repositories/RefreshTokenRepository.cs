using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class RefreshTokenRepository(RaizesDoNordesteDbContext dbContext) : IRefreshTokenWriteOnlyRepository
{
    public async Task Salvar(RefreshToken refreshToken)
    {
        await dbContext.AddAsync(refreshToken);
    }

    public async Task Remover(Guid usuarioId)
    {
        var tokens = await dbContext.RefreshTokens.Where(rt => rt.UsuarioId == usuarioId).ToListAsync();
        dbContext.RefreshTokens.RemoveRange(tokens);
    }
}
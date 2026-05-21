using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.RefreshToken;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class RefreshTokenRepository(RaizesDoNordesteDbContext dbContext)
    : IRefreshTokenReadOnlyRepository, IRefreshTokenWriteOnlyRepository
{
    public async Task<RefreshToken?> BuscarToken(string refreshToken)
    {
        return await dbContext.RefreshTokens.Include(rt => rt.Usuario)
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken);
    }

    public async Task Salvar(RefreshToken refreshToken) => await dbContext.AddAsync(refreshToken);

    public async Task Remover(Guid usuarioId)
    {
        var tokens = await dbContext.RefreshTokens.Where(rt => rt.UsuarioId == usuarioId).ToListAsync();
        dbContext.RefreshTokens.RemoveRange(tokens);
    }
}
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories;

public interface IRefreshTokenReadOnlyRepository
{
    Task<RefreshToken?> BuscarToken(string refreshToken);
}
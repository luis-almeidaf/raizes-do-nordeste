namespace RaizesDoNordeste.Domain.Repositories.RefreshToken;

public interface IRefreshTokenReadOnlyRepository
{
    Task<Entities.RefreshToken?> BuscarToken(string refreshToken);
}
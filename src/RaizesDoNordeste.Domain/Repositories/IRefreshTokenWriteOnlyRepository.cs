namespace RaizesDoNordeste.Domain.Repositories;

public interface IRefreshTokenWriteOnlyRepository
{
    Task Salvar(Entities.RefreshToken refreshToken);
}
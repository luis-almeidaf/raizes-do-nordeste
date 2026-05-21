namespace RaizesDoNordeste.Domain.Repositories.RefreshToken;

public interface IRefreshTokenWriteOnlyRepository
{
    Task Salvar(Entities.RefreshToken refreshToken);
    Task Remover(Guid usuarioId);
}
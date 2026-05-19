using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories;

public interface IRefreshTokenWriteOnlyRepository
{
    Task Salvar(RefreshToken refreshToken);
    Task Remover(Guid usuarioId);
}
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> EmailJaCadastrado(string email);
    Task<Usuario?> BuscarUsuarioPorEmail(string email);
}
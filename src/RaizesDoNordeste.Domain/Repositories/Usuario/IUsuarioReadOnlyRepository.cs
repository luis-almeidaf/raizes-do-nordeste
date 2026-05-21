namespace RaizesDoNordeste.Domain.Repositories.Usuario;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> EmailJaCadastrado(string email);
    Task<Entities.Usuario?> BuscarUsuarioPorEmail(string email);
}
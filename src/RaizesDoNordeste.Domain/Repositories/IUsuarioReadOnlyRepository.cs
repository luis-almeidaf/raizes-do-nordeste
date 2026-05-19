namespace RaizesDoNordeste.Domain.Repositories;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> EmailJaCadastrado(string email);
}
namespace RaizesDoNordeste.Domain.Repositories.Usuario;

public interface IUsuarioWriteOnlyRepository
{
    Task Cadastrar(Entities.Usuario usuario);
}
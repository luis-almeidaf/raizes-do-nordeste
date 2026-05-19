using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories;

public interface IUsuarioWriteOnlyRepository
{
    Task Cadastrar(Usuario usuario);
}
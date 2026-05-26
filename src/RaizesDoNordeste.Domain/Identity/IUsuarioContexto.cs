using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Identity;

public interface IUsuarioContexto
{
    Task<Usuario> BuscarUsuarioAutenticado();
}
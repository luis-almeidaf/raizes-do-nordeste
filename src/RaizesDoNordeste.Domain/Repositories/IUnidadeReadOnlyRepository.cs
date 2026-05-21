using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories;

public interface IUnidadeReadOnlyRepository
{
    Task<List<Unidade>> BuscarUnidades();
}
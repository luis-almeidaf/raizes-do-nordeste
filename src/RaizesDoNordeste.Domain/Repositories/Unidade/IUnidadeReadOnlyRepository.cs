using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Repositories.Unidade;

public interface IUnidadeReadOnlyRepository
{
    Task<List<Entities.Unidade>> BuscarUnidades();
    Task<Entities.Unidade?> BuscarUnidadePorId(int unidadeId);

    Task<List<ItemEstoque>> BuscarItensEstoque(int unidadeId);
}
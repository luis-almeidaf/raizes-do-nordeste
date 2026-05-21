namespace RaizesDoNordeste.Domain.Repositories.Unidade;

public interface IUnidadeReadOnlyRepository
{
    Task<List<Entities.Unidade>> BuscarUnidades();
}
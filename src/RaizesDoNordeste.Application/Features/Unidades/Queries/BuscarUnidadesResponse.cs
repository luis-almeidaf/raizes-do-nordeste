using RaizesDoNordeste.Application.Features.Unidades.Queries.Responses;
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Application.Features.Unidades.Queries;

public class BuscarUnidadesResponse
{
    public List<UnidadeResponse> Unidades { get; set; } = [];
}
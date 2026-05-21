using MediatR;
using RaizesDoNordeste.Application.Features.Unidades.Queries.Responses;
using RaizesDoNordeste.Domain.Repositories;

namespace RaizesDoNordeste.Application.Features.Unidades.Queries;

public class BuscarUnidadesQueryHandler(IUnidadeReadOnlyRepository unidadeRepository)
    : IRequestHandler<BuscarUnidadesQuery, BuscarUnidadesResponse>
{
    public async Task<BuscarUnidadesResponse> Handle(BuscarUnidadesQuery request, CancellationToken cancellationToken)
    {
        var listaDeUnidades = await unidadeRepository.BuscarUnidades();

        var resultado = listaDeUnidades
            .Select(unidade => new UnidadeResponse { UnidadeId = unidade.Id, Nome = unidade.Nome }).ToList();

        return new BuscarUnidadesResponse { Unidades = resultado };
    }
}
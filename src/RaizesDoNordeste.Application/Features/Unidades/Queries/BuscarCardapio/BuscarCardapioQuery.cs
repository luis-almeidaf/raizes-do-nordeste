using MediatR;

namespace RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;

public class BuscarCardapioQuery : IRequest<BuscarCardapioResponse>
{
    public int UnidadeId { get; set; }
}
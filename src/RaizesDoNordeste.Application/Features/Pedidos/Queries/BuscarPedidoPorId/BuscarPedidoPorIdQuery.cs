using MediatR;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidoPorId;

public class BuscarPedidoPorIdQuery : IRequest<BuscarPedidoPorIdResponse>
{
    public int PedidoId { get; set; }
}
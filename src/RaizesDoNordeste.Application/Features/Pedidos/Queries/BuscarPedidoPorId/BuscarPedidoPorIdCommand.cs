using MediatR;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries;

public class BuscarPedidoPorIdCommand : IRequest<BuscarPedidoPorIdResponse>
{
    public int PedidoId { get; set; }
}
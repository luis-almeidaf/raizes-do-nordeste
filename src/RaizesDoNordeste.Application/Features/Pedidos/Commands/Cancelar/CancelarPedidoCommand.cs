using MediatR;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.Cancelar;

public class CancelarPedidoCommand : IRequest<CancelarPedidoResponse>
{
    public int PedidoId { get; set; }
}
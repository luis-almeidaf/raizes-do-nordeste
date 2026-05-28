using MediatR;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;

public class AtualizarStatusCommand : IRequest<AtualizarStatusResponse>
{
    public int PedidoId { get; set; }
    public Status StatusPedido { get; set; }
}
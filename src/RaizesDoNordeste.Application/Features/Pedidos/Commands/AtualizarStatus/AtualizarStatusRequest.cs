using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;

public class AtualizarStatusRequest
{
    public Status StatusPedido { get; set; }
}
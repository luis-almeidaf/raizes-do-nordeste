using MediatR;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;

public class CriarPedidoCommand : IRequest<CriarPedidoResponse>
{
    public CanalPedido CanalPedido;
    public List<ItemPedidoRequest> ItensPedido = [];
    public int UnidadeId { get; set; }
    public string FormaDePagamento { get; set; } = string.Empty;
}
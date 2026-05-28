using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;

public class CriarPedidoRequest
{
    public int UnidadeId { get; set; }
    public CanalPedido CanalPedido { get; set; }
    public string FormaDePagamento { get; set; } = string.Empty;
    public List<ItemPedidoRequest> ItensPedido { get; set; } = null!;
}
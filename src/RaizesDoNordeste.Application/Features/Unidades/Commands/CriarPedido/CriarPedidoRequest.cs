using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;

public class CriarPedidoRequest
{
    public CanalPedido CanalPedido { get; set; }
    public string FormaDePagamento { get; set; } = string.Empty;
    public List<ItemPedidoRequest> ItensPedido { get; set; } = null!;
}
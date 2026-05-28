using MediatR;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;

public class CriarPedidoCommand : IRequest<CriarPedidoResponse>
{
    public CanalPedido CanalPedido;
    public List<ItemPedidoRequest> ItensPedido = [];
    public int UnidadeId;
    public string FormaDePagamento { get; set; } = string.Empty;
}
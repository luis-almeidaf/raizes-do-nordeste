using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidoPorId;

public class BuscarPedidoPorIdResponse
{
    public int PedidoId { get; set; }
    public Guid ClienteId { get; set; }
    public int UnidadeId { get; set; }
    public CanalPedido CanalPedido { get; set; }
    public string FormaDePagamento { get; set; } = string.Empty;
    public Status Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }
    public ICollection<ItemPedidoResponse> ItensPedido { get; set; } = new List<ItemPedidoResponse>();

    public static BuscarPedidoPorIdResponse Criar(Pedido pedido, List<ItemPedido> itensPedido) => new()
    {
        PedidoId = pedido.Id,
        ClienteId = pedido.ClienteId,
        UnidadeId = pedido.UnidadeId,
        CanalPedido = pedido.CanalPedido,
        FormaDePagamento = pedido.FormaDePagamento,
        Status = pedido.Status,
        ValorTotal = pedido.ValorTotal,
        DataPedido = pedido.DataPedido,
        ItensPedido = ConverterParaItensPedidoResponse(itensPedido)
    };

    private static List<ItemPedidoResponse> ConverterParaItensPedidoResponse(IEnumerable<ItemPedido> itensPedido)
    {
        return itensPedido.Select(itemPedido =>
            ItemPedidoResponse.Criar(itemPedido.ProdutoId, itemPedido.Produto.Nome, itemPedido.Quantidade,
                itemPedido.PrecoUnitario)).ToList();
    }
}
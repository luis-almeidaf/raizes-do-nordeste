using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;

public class CriarPedidoResponse
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public int UnidadeId { get; set; }
    public CanalPedido CanalPedido { get; set; }
    public Status Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }

    public static CriarPedidoResponse Criar(int id, Guid clienteId, int unidadeId, CanalPedido canalPedido,
        Status status, decimal valorTotal) => new()
    {
        Id = id,
        ClienteId = clienteId,
        UnidadeId = unidadeId,
        CanalPedido = canalPedido,
        Status = status,
        ValorTotal = valorTotal,
        DataPedido = DateTime.UtcNow
    };
}
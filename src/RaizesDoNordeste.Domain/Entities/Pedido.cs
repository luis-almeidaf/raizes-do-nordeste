using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public int UnidadeId { get; set; }
    public CanalPedido CanalPedido { get; set; }
    public Status Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }

    public ICollection<ItemPedido> ItensPedido { get; set; } = [];

    public static Pedido Criar(Guid clienteId, int unidadeId, CanalPedido canalPedido, decimal valorTotal) => new()
    {
        ClienteId = clienteId,
        UnidadeId = unidadeId,
        CanalPedido = canalPedido,
        Status = Status.AguardandoPagamento,
        ValorTotal = valorTotal,
        DataPedido = DateTime.UtcNow
    };

    public void AdicionarItens(List<ItemPedido> itensPedido)
    {
        foreach (var itemPedido in itensPedido) ItensPedido.Add(itemPedido);
    }

    public void AtualizarStatus(Status novoStatus) => Status = novoStatus;
}
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public int UnidadeId { get; set; }
    public CanalPedido CanalPedido { get; set; }
    public string FormaDePagamento { get; set; } = string.Empty;
    public Status Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }

    public ICollection<ItemPedido> ItensPedido { get; set; } = [];

    public static Pedido Criar(Guid clienteId, int unidadeId, CanalPedido canalPedido, string formaDePagamento) => new()
    {
        ClienteId = clienteId,
        UnidadeId = unidadeId,
        CanalPedido = canalPedido,
        FormaDePagamento = formaDePagamento,
        Status = Status.AguardandoPagamento,
        DataPedido = DateTime.UtcNow
    };

    public bool PertenceAoUsuarioLogado(Guid clienteId) => clienteId == ClienteId;

    public void CalcularValorTotal() =>
        ValorTotal = ItensPedido.Sum(itemPedido => itemPedido.PrecoUnitario * itemPedido.Quantidade);


    public void AdicionarItens(List<ItemPedido> itensPedido)
    {
        foreach (var itemPedido in itensPedido) ItensPedido.Add(itemPedido);
    }

    public void AtualizarStatus(Status novoStatus) => Status = novoStatus;
}
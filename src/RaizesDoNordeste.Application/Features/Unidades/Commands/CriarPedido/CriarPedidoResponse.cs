namespace RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;

public class CriarPedidoResponse
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public int UnidadeId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataPedido { get; set; }

    public static CriarPedidoResponse Criar(int id, Guid clienteId, int unidadeId, decimal valorTotal) => new()
    {
        Id = id,
        ClienteId = clienteId,
        UnidadeId = unidadeId,
        ValorTotal = valorTotal,
        DataPedido = DateTime.UtcNow
    };
}
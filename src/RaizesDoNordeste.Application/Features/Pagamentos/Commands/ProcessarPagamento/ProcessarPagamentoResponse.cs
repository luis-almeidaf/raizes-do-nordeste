namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoResponse
{
    public int PedidoId { get; set; }
    public string StatusPagamento { get; set; } = null!;

    public static ProcessarPagamentoResponse Criar(int pedidoId, string statusPagamento) => new()
    {
        PedidoId = pedidoId,
        StatusPagamento = statusPagamento
    };
}
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoRequest
{
    public StatusPagamento StatusPagamento { get; set; }
}
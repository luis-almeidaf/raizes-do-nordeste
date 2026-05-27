using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoRequest
{
    public FormaDePagamento FormaDePagamento { get; set; }
}
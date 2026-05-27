using MediatR;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoCommand : IRequest<ProcessarPagamentoResponse>
{
    public int PedidoId { get; set; }
    public FormaDePagamento FormaDePagamento { get; set; }
}
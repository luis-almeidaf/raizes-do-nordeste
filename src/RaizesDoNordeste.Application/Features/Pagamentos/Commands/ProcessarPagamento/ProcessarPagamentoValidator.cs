using FluentValidation;
using RaizesDoNordeste.Exceptions;

namespace RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;

public class ProcessarPagamentoValidator : AbstractValidator<ProcessarPagamentoCommand>
{
    public ProcessarPagamentoValidator()
    {
        RuleFor(pagamento => pagamento.StatusPagamento).NotEmpty()
            .WithMessage(MensagensDeErro.STATUS_DO_PAGAMENTO_VAZIO);
        RuleFor(pagamento => pagamento.StatusPagamento).IsInEnum()
            .WithMessage(MensagensDeErro.STATUS_DO_PAGAMENTO_INVALIDO);
    }
}
using FluentValidation;
using RaizesDoNordeste.Exceptions;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;

public class AtualizarStatusValidator : AbstractValidator<AtualizarStatusCommand>
{
    public AtualizarStatusValidator()
    {
        RuleFor(pedido => pedido.StatusPedido).IsInEnum().WithMessage(MensagensDeErro.STATUS_DO_PEDIDO_INVALIDO);
        RuleFor(pedido => pedido.StatusPedido).NotEmpty().WithMessage(MensagensDeErro.STATUS_DO_PEDIDO_VAZIO);
    }
}
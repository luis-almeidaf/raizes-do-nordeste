using FluentValidation;
using RaizesDoNordeste.Exceptions;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;

public class CriarPedidoValidator : AbstractValidator<CriarPedidoCommand>
{
    public CriarPedidoValidator()
    {
        RuleFor(pedido => pedido.CanalPedido).NotEmpty().WithMessage(MensagensDeErro.CANAL_PEDIDO_VAZIO);
        RuleFor(pedido => pedido.CanalPedido).IsInEnum().WithMessage(MensagensDeErro.CANAL_PEDIDO_INVALIDO);
        RuleFor(pedido => pedido.ItensPedido).NotEmpty().WithMessage(MensagensDeErro.PEDIDO_SEM_ITENS);
        RuleFor(pedido => pedido.FormaDePagamento).NotEmpty().WithMessage(MensagensDeErro.FORMA_DE_PAGAMENTO_VAZIA);
        RuleForEach(pedido => pedido.ItensPedido)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ProdutoId).GreaterThan(0).WithMessage(MensagensDeErro.PRODUTO_ID_INVALIDO);
                item.RuleFor(i => i.Quantidade).GreaterThan(0).WithMessage(MensagensDeErro.QUANTIDADE_INVALIDA);
            });
    }
}
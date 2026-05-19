using FluentValidation;
using RaizesDoNordeste.Application.Common.PasswordValidator;
using RaizesDoNordeste.Exceptions;

namespace RaizesDoNordeste.Application.Features.Auth.Commands.CadastrarUsuarioCommand;

public class CadastrarUsuarioValidator : AbstractValidator<CadastrarUsuarioCommand>
{
    public CadastrarUsuarioValidator()
    {
        RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(MensagensDeErro.NOME_VAZIO);
        RuleFor(usuario => usuario.Sobrenome).NotEmpty().WithMessage(MensagensDeErro.SOBRENOME_VAZIO);
        RuleFor(usuario => usuario.Email)
            .NotEmpty()
            .WithMessage(MensagensDeErro.EMAIL_VAZIO)
            .EmailAddress()
            .When(usuario => !string.IsNullOrWhiteSpace(usuario.Email), ApplyConditionTo.CurrentValidator)
            .WithMessage(MensagensDeErro.EMAIL_INVALIDO);

        RuleFor(usuario => usuario.Senha)
            .SetValidator(new PasswordValidator<CadastrarUsuarioCommand>())
            .WithMessage(MensagensDeErro.SENHA_INVALIDA);
    }
}
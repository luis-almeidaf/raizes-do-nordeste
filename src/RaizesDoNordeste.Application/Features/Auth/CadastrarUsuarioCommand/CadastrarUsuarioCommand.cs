using MediatR;

namespace RaizesDoNordeste.Application.Features.Auth.CadastrarUsuarioCommand;

public class CadastrarUsuarioCommand : IRequest<CadastrarUsuarioResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
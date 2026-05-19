using MediatR;

namespace RaizesDoNordeste.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
using MediatR;

namespace RaizesDoNordeste.Application.Features.Auth.Commands.RefreshTokenLogin;

public class RefreshTokenLoginCommand : IRequest<RefreshTokenLoginResponse>
{
    public string RefreshToken { get; set; } = string.Empty;
}
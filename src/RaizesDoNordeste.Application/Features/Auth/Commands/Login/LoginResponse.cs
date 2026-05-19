namespace RaizesDoNordeste.Application.Features.Auth.Commands.Login;

public class LoginResponse
{
    public Guid UsuarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
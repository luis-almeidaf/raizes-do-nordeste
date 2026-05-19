namespace RaizesDoNordeste.Application.Features.Auth.CadastrarUsuarioCommand;

public class CadastrarUsuarioResponse
{
    public Guid Id {get; set;}
    public string Nome { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
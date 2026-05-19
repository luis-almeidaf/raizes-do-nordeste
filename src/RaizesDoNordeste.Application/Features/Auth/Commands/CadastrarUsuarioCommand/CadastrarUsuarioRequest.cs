namespace RaizesDoNordeste.Application.Features.Auth.Commands.CadastrarUsuarioCommand;

public class CadastrarUsuarioRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Sobrenome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;
    public Role Role { get; private set; }

    public int? UnidadeId { get; init; }
    public Unidade? Unidade { get; init; }

    public static Usuario Criar(string nome, string sobrenome, string email) => new()
    {
        Id = Guid.NewGuid(),
        Nome = nome,
        Sobrenome = sobrenome,
        Email = email,
        Role = Role.Cliente
    };

    public void DefinirSenha(string senhaHash) => Senha = senhaHash;
}
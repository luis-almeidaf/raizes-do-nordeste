namespace RaizesDoNordeste.Domain.Entities;

public class Unidade
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public ICollection<Usuario> Funcionarios { get; } = [];

    public Estoque Estoque { get; private set; } = null!;
}
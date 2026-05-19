namespace RaizesDoNordeste.Domain.Entities;

public class Unidade
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Usuario> Usuarios { get; set; } = [];
}
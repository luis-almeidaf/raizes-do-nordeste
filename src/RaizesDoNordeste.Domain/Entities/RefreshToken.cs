namespace RaizesDoNordeste.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = null!;
    public Guid UsuarioId { get; set; }
    public DateTime ExpiraEm { get; set; }

    public Usuario Usuario { get; set; } = null!;

    public static RefreshToken Criar(string token, Guid usuarioId)
    {
        return new RefreshToken()
        {
            Id = Guid.NewGuid(),
            Token = token,
            UsuarioId = usuarioId,
            ExpiraEm = DateTime.UtcNow.AddDays(7),
        };
    }
}
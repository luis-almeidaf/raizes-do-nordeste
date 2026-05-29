namespace RaizesDoNordeste.Domain.Entities;

public class Auditoria
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public int UnidadeId { get; set; }
    public string TipoOperacao { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }

    public static Auditoria Criar(Guid usuarioId, int unidadeId, string tipoOperacao) => new()
    {
        Id = Guid.NewGuid(),
        UsuarioId = usuarioId,
        UnidadeId = unidadeId,
        TipoOperacao = tipoOperacao,
        DataHora = DateTime.UtcNow
    };
}
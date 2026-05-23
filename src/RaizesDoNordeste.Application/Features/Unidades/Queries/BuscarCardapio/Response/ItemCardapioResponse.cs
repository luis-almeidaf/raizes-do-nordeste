namespace RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio.Response;

public class ItemCardapioResponse
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public static ItemCardapioResponse Criar(int produtoId, string nome, string descricao) => new()
    {
        ProdutoId = produtoId,
        Nome = nome,
        Descricao = descricao
    };
}
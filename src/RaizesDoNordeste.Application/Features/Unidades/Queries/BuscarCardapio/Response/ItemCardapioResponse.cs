namespace RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio.Response;

public class ItemCardapioResponse
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    public static ItemCardapioResponse Criar(int produtoId, string nome, string descricao, decimal preco) => new()
    {
        ProdutoId = produtoId,
        Nome = nome,
        Descricao = descricao,
        Preco = preco
    };
}
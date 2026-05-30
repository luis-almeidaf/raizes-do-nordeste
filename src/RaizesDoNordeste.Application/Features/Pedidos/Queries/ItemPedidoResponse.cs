namespace RaizesDoNordeste.Application.Features.Pedidos.Queries;

public class ItemPedidoResponse
{
    public int ProdutoId { get; set; }
    public string ProdutoNome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public static ItemPedidoResponse Criar(int produtoId, string produtoNome, int quantidade, decimal precoUnitario) =>
        new()
        {
            ProdutoId = produtoId,
            ProdutoNome = produtoNome,
            Quantidade = quantidade,
            PrecoUnitario = precoUnitario
        };
}
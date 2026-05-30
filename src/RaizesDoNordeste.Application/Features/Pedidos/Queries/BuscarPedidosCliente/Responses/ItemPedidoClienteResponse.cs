namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosCliente.Responses;

public class ItemPedidoClienteResponse
{
    public int ProdutoId { get; set; }
    public string ProdutoNome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public static ItemPedidoClienteResponse Criar(int produtoId, string produtoNome, int quantidade, decimal precoUnitario) =>
        new()
        {
            ProdutoId = produtoId,
            ProdutoNome = produtoNome,
            Quantidade = quantidade,
            PrecoUnitario = precoUnitario
        };
}
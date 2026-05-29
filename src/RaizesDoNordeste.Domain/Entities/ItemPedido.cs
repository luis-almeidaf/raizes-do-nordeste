namespace RaizesDoNordeste.Domain.Entities;

public class ItemPedido
{
    public Guid Id { get; set; }
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public Pedido Pedido { get; set; } = null!;
    public Produto Produto { get; set; } = null!;

    public static ItemPedido Criar(int produtoId, decimal precoUnitario, int quantidade) => new()
    {
        Id = Guid.NewGuid(),
        ProdutoId = produtoId,
        PrecoUnitario = precoUnitario,
        Quantidade = quantidade
    };
}
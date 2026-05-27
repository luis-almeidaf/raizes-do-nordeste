namespace RaizesDoNordeste.Domain.Entities;

public class ItemPedido
{
    public Guid Id { get; set; }
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }

    public Pedido Pedido { get; set; } = null!;
    public Produto Produto { get; set; } = null!;

    public static ItemPedido Criar(int produtoId, int quantidade) => new()
    {
        Id = Guid.NewGuid(),
        ProdutoId = produtoId,
        Quantidade = quantidade
    };
}
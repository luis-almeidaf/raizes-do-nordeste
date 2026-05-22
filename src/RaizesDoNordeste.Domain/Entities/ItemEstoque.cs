namespace RaizesDoNordeste.Domain.Entities;

public class ItemEstoque
{
    public Guid Id { get; set; }
    public int ProdutoId { get; set; }
    public Guid EstoqueId { get; set; }

    public int Quantidade { get; set; }

    public Produto Produto { get; set; } = null!;
    public Estoque Estoque { get; set; } = null!;

    public void AumentarQuantidade(int quantidade) => Quantidade += quantidade;

    public bool DiminuirQuantidade(int quantidade)
    {
        if (quantidade > Quantidade)
            return false;

        Quantidade -= quantidade;
        return true;
    }
}
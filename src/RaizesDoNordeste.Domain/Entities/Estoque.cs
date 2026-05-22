namespace RaizesDoNordeste.Domain.Entities;

public class Estoque
{
    public Guid Id { get; set; }
    public int UnidadeId { get; set; }

    private ICollection<ItemEstoque> Itens { get; } = [];

    public void AdicionarItemAoEstoque(int produtoId, int quantidade)
    {
        Itens.Add(new ItemEstoque { ProdutoId = produtoId, Quantidade = quantidade });
    }
}
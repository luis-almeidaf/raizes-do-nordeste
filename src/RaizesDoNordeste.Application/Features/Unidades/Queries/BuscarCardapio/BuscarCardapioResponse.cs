using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio.Response;

namespace RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;

public class BuscarCardapioResponse
{
    public int UnidadeId { get; init; }
    public string UnidadeNome { get; init; } = string.Empty;
    public List<ItemCardapioResponse> Cardapio { get; set; } = [];

    public static BuscarCardapioResponse Criar(int id, string nome, List<ItemCardapioResponse> cardapio) => new()
    {
        UnidadeId = id,
        UnidadeNome = nome,
        Cardapio = cardapio
    };
}
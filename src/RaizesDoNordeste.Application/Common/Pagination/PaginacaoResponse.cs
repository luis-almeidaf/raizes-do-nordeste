namespace RaizesDoNordeste.Application.Common.Pagination;

public class PaginacaoResponse<T>
{
    public List<T> Itens { get; init; } = [];
    public int Pagina { get; init; }
    public int TamanhoPagina { get; init; }
    public int TotalRegistros { get; init; }
    public int TotalPaginas { get; init; }
}
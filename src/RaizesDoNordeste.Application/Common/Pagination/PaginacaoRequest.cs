namespace RaizesDoNordeste.Application.Common.Pagination;

public class PaginacaoRequest
{
    public int Pagina { get; init; } = 1;
    public int TamanhoPagina { get; init; } = 10;
}
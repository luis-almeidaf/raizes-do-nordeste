using MediatR;
using RaizesDoNordeste.Application.Common.Pagination;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosUnidade;

public class BuscarPedidosUnidadeQuery : PaginacaoRequest, IRequest<BuscarPedidosUnidadeResponse>
{
    public CanalPedido? CanalPedido { get; set; }
    public Status? Status { get; set; }
}
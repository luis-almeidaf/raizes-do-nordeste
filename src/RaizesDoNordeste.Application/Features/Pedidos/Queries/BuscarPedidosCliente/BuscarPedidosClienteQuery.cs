using MediatR;
using RaizesDoNordeste.Application.Common.Pagination;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosCliente;

public class BuscarPedidosClienteQuery : PaginacaoRequest, IRequest<BuscarPedidosClienteResponse>
{
    public Status? Status { get; set; }
}
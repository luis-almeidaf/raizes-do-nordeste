using MediatR;
using RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosCliente.Responses;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories.Pedido;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosCliente;

public class BuscarPedidosClienteQueryHandler(
    IPedidoReadOnlyRepository pedidoRepo,
    IUsuarioContexto usuarioContexto)
    : IRequestHandler<BuscarPedidosClienteQuery, BuscarPedidosClienteResponse>
{
    public async Task<BuscarPedidosClienteResponse> Handle(BuscarPedidosClienteQuery request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var (listaDePedidos, total) =
            await pedidoRepo.BuscarPedidosDoCliente(usuario.Id, request.Pagina, request.TamanhoPagina, request.Status);

        var resultado = listaDePedidos.Select(pedido => PedidosResponse.Criar(pedido, pedido.ItensPedido.ToList()));

        return new BuscarPedidosClienteResponse
        {
            Itens = resultado.ToList(),
            Pagina = request.Pagina,
            TamanhoPagina = request.TamanhoPagina,
            TotalRegistros = total,
            TotalPaginas = (int)Math.Ceiling((double)total / request.TamanhoPagina)
        };
    }
}
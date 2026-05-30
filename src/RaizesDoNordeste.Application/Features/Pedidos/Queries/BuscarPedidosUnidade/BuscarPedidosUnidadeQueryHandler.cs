using MediatR;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Domain.Enums;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories.Pedido;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosUnidade;

public class BuscarPedidosUnidadeQueryHandler(
    IUsuarioContexto usuarioContexto,
    IPedidoReadOnlyRepository pedidoRepo)
    : IRequestHandler<BuscarPedidosUnidadeQuery, BuscarPedidosUnidadeResponse>
{
    public async Task<BuscarPedidosUnidadeResponse> Handle(BuscarPedidosUnidadeQuery request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();
        var unidadeId = usuario.Role == Role.Administrador ? null : usuario.UnidadeId;

        var (listaDePedidos, total) =
            await pedidoRepo.BuscarPedidosUnidade(unidadeId, request.Pagina, request.TamanhoPagina,
                request.Status, request.CanalPedido);

        var resultado = listaDePedidos.Select(pedido => PedidosResponse.Criar(pedido, pedido.ItensPedido.ToList()));

        return new BuscarPedidosUnidadeResponse
        {
            Itens = resultado.ToList(),
            Pagina = request.Pagina,
            TamanhoPagina = request.TamanhoPagina,
            TotalRegistros = total,
            TotalPaginas = (int)Math.Ceiling((double)total / request.TamanhoPagina)
        };
    }
}
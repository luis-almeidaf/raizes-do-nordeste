using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidoPorId;

public class BuscarPedidoPorIdQueryHandler(IUsuarioContexto usuarioContexto, IPedidoReadOnlyRepository pedidoRepo)
    : IRequestHandler<BuscarPedidoPorIdQuery, BuscarPedidoPorIdResponse>
{
    public async Task<BuscarPedidoPorIdResponse> Handle(BuscarPedidoPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var pedido = await pedidoRepo.BuscarPorId(request.PedidoId, usuario.Id);
        if (pedido == null)
            throw new PedidoNaoEncontradoException();

        var itensPedido = new List<ItemPedido>(pedido.ItensPedido);

        return BuscarPedidoPorIdResponse.Criar(pedido, itensPedido);
    }
}
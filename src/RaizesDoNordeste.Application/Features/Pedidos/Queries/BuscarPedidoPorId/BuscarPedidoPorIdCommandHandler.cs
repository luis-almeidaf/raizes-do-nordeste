using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pedidos.Queries;

public class BuscarPedidoPorIdCommandHandler(IUsuarioContexto usuarioContexto, IPedidoReadOnlyRepository pedidoRepo)
    : IRequestHandler<BuscarPedidoPorIdCommand, BuscarPedidoPorIdResponse>
{
    public async Task<BuscarPedidoPorIdResponse> Handle(BuscarPedidoPorIdCommand request,
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
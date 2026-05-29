using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Repositories.Auditoria;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.Cancelar;

public class CancelarPedidoCommandHandler(
    IAuditoriaRepository auditoriaRepo,
    IUsuarioContexto usuarioContexto,
    IPedidoWriteOnlyRepository pedidoRepo,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelarPedidoCommand, CancelarPedidoResponse>
{
    public async Task<CancelarPedidoResponse> Handle(CancelarPedidoCommand request, CancellationToken cancellationToken)
    {
        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();

        var pedido = await BuscarPedido(request.PedidoId, usuario.Id);
        if (!pedido.Cancelar())
            throw new OperacaoNaoPermitaException("Seu pedido já está em preparo/pronto e não pode ser cancelado");

        var auditoria = Auditoria.Criar(pedido.ClienteId, pedido.UnidadeId, "Cancelamento");

        pedidoRepo.AtualizarPedido(pedido);
        auditoriaRepo.Salvar(auditoria);
        await unitOfWork.Commit();

        return CancelarPedidoResponse.Criar("Pedido cancelado");
    }

    private async Task<Pedido> BuscarPedido(int pedidoId, Guid usuarioId)
    {
        var pedido = await pedidoRepo.BuscarPorId(pedidoId);
        if (pedido is null)
            throw new PedidoNaoEncontradoException();

        return !pedido.PertenceAoUsuarioLogado(usuarioId) ? throw new PedidoNaoPertenceAoUsuarioException() : pedido;
    }
}
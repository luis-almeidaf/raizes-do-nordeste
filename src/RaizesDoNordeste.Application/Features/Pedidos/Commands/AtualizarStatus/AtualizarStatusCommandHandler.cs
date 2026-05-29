using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Enums;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Repositories.Pedido;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;

public class AtualizarStatusCommandHandler(
    IPedidoWriteOnlyRepository pedidoRepo,
    IUsuarioContexto usuarioContexto,
    IUnitOfWork unitOfWork) : IRequestHandler<AtualizarStatusCommand, AtualizarStatusResponse>
{
    public async Task<AtualizarStatusResponse> Handle(AtualizarStatusCommand request,
        CancellationToken cancellationToken)
    {
        ValidarRequest(request);

        var usuario = await usuarioContexto.BuscarUsuarioAutenticado();
        var pedido = await BuscarPedido(request.PedidoId, usuario.Id);

        ValidarUnidadeDoUsuarioEDoPedido(usuario, pedido);
        ValidarAtualizacaoDePedido(request, pedido);

        pedidoRepo.AtualizarPedido(pedido);
        await unitOfWork.Commit();

        return AtualizarStatusResponse.Criar(pedido.Status, "Pedido atualizado com sucesso");
    }

    private static void ValidarRequest(AtualizarStatusCommand request)
    {
        var resultado = new AtualizarStatusValidator().Validate(request);

        if (resultado.IsValid) return;

        var erros = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
        throw new ErroDeValidacaoException(erros);
    }

    private async Task<Pedido> BuscarPedido(int pedidoId, Guid usuarioId)
    {
        var pedido = await pedidoRepo.BuscarPorId(pedidoId);
        return pedido ?? throw new PedidoNaoEncontradoException();
    }

    private static void ValidarUnidadeDoUsuarioEDoPedido(Usuario usuario, Pedido pedido)
    {
        if (usuario.UnidadeId != pedido.UnidadeId)
            throw new OperacaoNaoPermitaException("O usuário não pertence a unidade do pedido");
    }

    private static void ValidarAtualizacaoDePedido(AtualizarStatusCommand request, Pedido pedido)
    {
        if ((pedido.Status == Status.Pago && request.StatusPedido == Status.EmPreparo) ||
            (pedido.Status == Status.EmPreparo && request.StatusPedido == Status.Pronto))
            pedido.AtualizarStatus(request.StatusPedido);
        else
            throw new OperacaoNaoPermitaException(
                $"Pedido com status {pedido.Status} não pode ser alterado para {request.StatusPedido}.");
    }
}
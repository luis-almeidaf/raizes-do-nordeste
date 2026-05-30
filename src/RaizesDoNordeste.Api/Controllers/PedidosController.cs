using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.Cancelar;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PedidosController(IMediator mediator) : ControllerBase
{
    private const string RolesOperacionais =
        $"{nameof(Role.Atendente)},{nameof(Role.Cozinha)},{nameof(Role.Gerente)}";

    [HttpPost]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(CriarPedidoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoRequest request)
    {
        var response = await mediator.Send(new CriarPedidoCommand
        {
            UnidadeId = request.UnidadeId,
            CanalPedido = request.CanalPedido,
            FormaDePagamento = request.FormaDePagamento,
            ItensPedido = request.ItensPedido
        });

        return Created(string.Empty, response);
    }


    [HttpPatch("atualizar-status/{pedidoId:int}")]
    [Authorize(Roles = RolesOperacionais)]
    [ProducesResponseType(typeof(AtualizarStatusResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AtualizarStatusDoPedido(
        [FromRoute] int pedidoId,
        [FromBody] AtualizarStatusRequest request)
    {
        var response = await mediator.Send(new AtualizarStatusCommand
        {
            PedidoId = pedidoId,
            StatusPedido = request.StatusPedido
        });

        return Ok(response);
    }

    [HttpPatch("cancelar/{pedidoId:int}")]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(CancelarPedidoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CancelarPedido([FromRoute] int pedidoId)
    {
        var response = await mediator.Send(new CancelarPedidoCommand
        {
            PedidoId = pedidoId
        });

        return Ok(response);
    }
}
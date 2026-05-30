using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.Cancelar;
using RaizesDoNordeste.Application.Features.Pedidos.Commands.CriarPedido;
using RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidoPorId;
using RaizesDoNordeste.Application.Features.Pedidos.Queries.BuscarPedidosCliente;
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


    [HttpGet("{pedidoId:int}")]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(BuscarPedidoPorIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarPedidoPorId([FromRoute] int pedidoId)
    {
        var response = await mediator.Send(new BuscarPedidoPorIdQuery
        {
            PedidoId = pedidoId
        });

        return Ok(response);
    }

    [HttpGet("meus")]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(BuscarPedidosClienteResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> BuscarPedidos([FromQuery] BuscarPedidosClienteQuery query)
    {
        var response = await mediator.Send(query);

        if (response.Itens.Count != 0)
            return Ok(response);

        return NoContent();
    }
}
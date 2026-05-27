using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarUnidades;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UnidadesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BuscarUnidadesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscarUnidades()
    {
        var response = await mediator.Send(new BuscarUnidadesQuery());
        return Ok(response);
    }

    [HttpGet("{unidadeId:int}/cardapio")]
    [ProducesResponseType(typeof(BuscarCardapioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarCardapio([FromRoute] int unidadeId)
    {
        var response = await mediator.Send(new BuscarCardapioQuery { UnidadeId = unidadeId });
        return Ok(response);
    }

    [HttpPost("{unidadeId:int}/pedidos/")]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(CriarPedidoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CriarPedido([FromRoute] int unidadeId, [FromBody] CriarPedidoRequest request)
    {
        var response = await mediator.Send(new CriarPedidoCommand
        {
            UnidadeId = unidadeId,
            CanalPedido = request.CanalPedido,
            ItensPedido = request.ItensPedido
        });

        return Created(string.Empty, response);
    }
}
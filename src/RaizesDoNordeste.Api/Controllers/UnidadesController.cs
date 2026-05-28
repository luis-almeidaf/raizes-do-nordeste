using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarUnidades;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UnidadesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BuscarUnidadesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarUnidades()
    {
        var response = await mediator.Send(new BuscarUnidadesQuery());

        if (response.Unidades.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpGet("{unidadeId:int}/cardapio")]
    [ProducesResponseType(typeof(BuscarCardapioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarCardapio([FromRoute] int unidadeId)
    {
        var response = await mediator.Send(new BuscarCardapioQuery { UnidadeId = unidadeId });

        if (response.Cardapio.Count != 0)
            return Ok(response);

        return NoContent();
    }
}
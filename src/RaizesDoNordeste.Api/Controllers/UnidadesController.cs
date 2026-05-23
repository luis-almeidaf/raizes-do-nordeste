using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarCardapio;
using RaizesDoNordeste.Application.Features.Unidades.Queries.BuscarUnidades;

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

    [HttpGet("{unidadeId:int}")]
    [ProducesResponseType(typeof(BuscarCardapioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarCardapio([FromRoute] int unidadeId)
    {
        var response = await mediator.Send(new BuscarCardapioQuery { UnidadeId = unidadeId });
        return Ok(response);
    }
}
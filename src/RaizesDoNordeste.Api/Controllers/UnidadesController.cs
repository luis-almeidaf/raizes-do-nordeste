using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Unidades.Queries;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UnidadesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(BuscarUnidadesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BuscarUnidades()
    {
        var response = await mediator.Send(new BuscarUnidadesQuery());
        return Ok(response);
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Pagamentos.Commands.ProcessarPagamento;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PagamentosController(IMediator mediator) : ControllerBase
{
    [HttpPatch("{pedidoId:int}")]
    [Authorize(Roles = nameof(Role.Cliente))]
    [ProducesResponseType(typeof(ProcessarPagamentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> ProcessarPagamento([FromRoute] int pedidoId,
        [FromBody] ProcessarPagamentoRequest request)
    {
        var response = await mediator.Send(new ProcessarPagamentoCommand
        {
            PedidoId = pedidoId,
            StatusPagamento = request.StatusPagamento
        });

        return Ok(response);
    }
}
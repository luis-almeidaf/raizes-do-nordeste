using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Unidades.Commands.CriarPedido;
using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PedidosController(IMediator mediator) : ControllerBase
{
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
}
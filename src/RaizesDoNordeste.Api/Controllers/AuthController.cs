using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Auth.CadastrarUsuarioCommand;

namespace RaizesDoNordeste.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("cadastro/")]
    [ProducesResponseType(typeof(CadastrarUsuarioResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioRequest request)
    {
        var response = await mediator.Send(new CadastrarUsuarioCommand
        {
            Nome = request.Nome,
            Sobrenome = request.Sobrenome,
            Email = request.Email,
            Senha = request.Senha
        });
        
        return Created(string.Empty, response);
    }
}
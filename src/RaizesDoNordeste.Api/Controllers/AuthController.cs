using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Application.Features.Auth.Commands.CadastrarUsuarioCommand;
using RaizesDoNordeste.Application.Features.Auth.Commands.Login;

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

    [HttpPost("login/")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErroBaseResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await mediator.Send(new LoginCommand
        {
            Email = request.Email,
            Senha = request.Senha
        });

        return Ok(response);
    }
}
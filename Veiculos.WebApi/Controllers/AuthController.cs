using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands;

namespace Veiculos.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var token = await mediator.Send(command);

        if (string.IsNullOrEmpty(token))
            return Unauthorized(new { message = "Usuário ou senha inválidos" });

        return Ok(new { token });
    }
}
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands;
using Veiculos.Application.Interfaces;

namespace Veiculos.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(IUsuarioService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarUsuarioCommand command)
    {
        var id = await service.AdicionarUsuario(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuario = await service.ObterPorId(id);
        return usuario != null ? Ok(usuario) : NotFound();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands;
using Veiculos.Application.Interfaces;

namespace Veiculos.WebApi.Controllers;

[Authorize] // Bloqueia acesso sem Token JWT
[ApiController]
[Route("api/[controller]")]
public class VeiculosController(IVeiculoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await service.ListarTodos());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AdicionarVeiculoCommand command)
    {
        var id = await service.Adicionar(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarVeiculoCommand command)
    {
        if (id != command.Id) return BadRequest("ID divergente.");
        var sucesso = await service.Atualizar(command);
        return sucesso ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var sucesso = await service.Excluir(id);
        return sucesso ? NoContent() : NotFound();
    }
}
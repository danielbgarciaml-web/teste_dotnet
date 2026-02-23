using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;
using Veiculos.Infra.Data;

namespace Veiculos.Infra.Repositories;

public class VeiculoRepository(AppDbContext context) : IVeiculoRepository
{
    public async Task<Veiculo?> ObterPorIdAsync(Guid id) => await context.Veiculos.FindAsync(id);
    public async Task<IEnumerable<Veiculo>> ListarTodosAsync() => await context.Veiculos.ToListAsync();
    public async Task AdicionarAsync(Veiculo v) { await context.Veiculos.AddAsync(v); await context.SaveChangesAsync(); }
    public async Task AtualizarAsync(Veiculo v) { context.Veiculos.Update(v); await context.SaveChangesAsync(); }
    public async Task RemoverAsync(Guid id)
    {
        var v = await ObterPorIdAsync(id);
        if (v != null) { context.Veiculos.Remove(v); await context.SaveChangesAsync(); }
    }
}
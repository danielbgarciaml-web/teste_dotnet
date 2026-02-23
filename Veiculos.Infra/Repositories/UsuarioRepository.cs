using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;
using Veiculos.Infra.Data;

namespace Veiculos.Infra.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<Usuario?> ObterPorIdAsync(Guid id) =>
        await context.Usuarios.FindAsync(id);

    public async Task<Usuario?> ObterPorLoginAsync(string login) =>
        await context.Usuarios.FirstOrDefaultAsync(u => u.Login == login);

    public async Task AdicionarAsync(Usuario usuario)
    {
        await context.Usuarios.AddAsync(usuario);
        await context.SaveChangesAsync();
    }
}
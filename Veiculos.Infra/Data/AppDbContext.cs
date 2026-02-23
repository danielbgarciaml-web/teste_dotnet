using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Entities;
namespace Veiculos.Infra.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
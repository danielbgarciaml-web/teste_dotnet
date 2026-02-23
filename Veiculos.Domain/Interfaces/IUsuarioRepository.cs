using Veiculos.Domain.Entities;
namespace Veiculos.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorIdAsync(Guid id);
    Task<Usuario?> ObterPorLoginAsync(string login);
    Task AdicionarAsync(Usuario usuario);
}
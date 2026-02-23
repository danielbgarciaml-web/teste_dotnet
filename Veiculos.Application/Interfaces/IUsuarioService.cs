using Veiculos.Application.Commands;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Interfaces;

public interface IUsuarioService
{
    Task<Guid> AdicionarUsuario(AdicionarUsuarioCommand command);
    Task<Usuario?> ObterPorId(Guid id);
}
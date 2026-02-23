using MediatR;
using Veiculos.Application.Interfaces;
using Veiculos.Application.Commands;
using Veiculos.Application.Queries;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Services;

public class UsuarioService(IMediator mediator) : IUsuarioService
{
    public async Task<Guid> AdicionarUsuario(AdicionarUsuarioCommand command) => await mediator.Send(command);
    public async Task<Usuario?> ObterPorId(Guid id) => await mediator.Send(new ObterUsuarioPorIdQuery(id));
}
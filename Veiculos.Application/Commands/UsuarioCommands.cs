using MediatR;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Commands;

public record AdicionarUsuarioCommand(string Nome, string Login, string Senha) : IRequest<Guid>;
public record ObterUsuarioPorIdQuery(Guid Id) : IRequest<Usuario?>;
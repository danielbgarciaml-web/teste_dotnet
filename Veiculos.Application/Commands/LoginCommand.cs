using MediatR;

namespace Veiculos.Application.Commands;

// Record exclusivo para o fluxo de entrada no sistema
public record LoginCommand(string Login, string Senha) : IRequest<string?>;
using MediatR;
using Veiculos.Application.Commands;
using Veiculos.Application.Interfaces;
using Veiculos.Domain.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Veiculos.Application.Handlers;

public class LoginHandler(IUsuarioRepository repository, IAuthService authService)
    : IRequestHandler<LoginCommand, string?>
{
    public async Task<string?> Handle(LoginCommand request, CancellationToken ct)
    {
        var usuario = await repository.ObterPorLoginAsync(request.Login);

        // Verifica se usuário existe e se a senha (hash) coincide
        if (usuario == null || !BC.Verify(request.Senha, usuario.SenhaHash))
            return null;

        // Se deu certo, gera e retorna o Token JWT
        return authService.GerarToken(usuario.Login, usuario.Id);
    }
}
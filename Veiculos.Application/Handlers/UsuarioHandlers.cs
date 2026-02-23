using MediatR;
using Veiculos.Application.Commands;
using Veiculos.Application.Queries;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Veiculos.Application.Handlers;

public class UsuarioHandlers(IUsuarioRepository repository) :
    IRequestHandler<AdicionarUsuarioCommand, Guid>,
    IRequestHandler<ObterUsuarioPorIdQuery, Usuario?>
{
    public async Task<Guid> Handle(AdicionarUsuarioCommand request, CancellationToken ct)
    {
        var usuario = new Usuario
        {
            Nome = request.Nome,
            Login = request.Login,
              SenhaHash = BC.HashPassword(request.Senha)
        };

        await repository.AdicionarAsync(usuario);
        return usuario.Id;
    }

  
    public async Task<Usuario?> Handle(ObterUsuarioPorIdQuery request, CancellationToken ct)
    {
        return await repository.ObterPorIdAsync(request.Id);
    }
}
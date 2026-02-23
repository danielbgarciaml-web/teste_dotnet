using MediatR;
using Veiculos.Application.Commands;
using Veiculos.Application.Interfaces;
using Veiculos.Application.Queries;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Services;

public class VeiculoService(IMediator mediator) : IVeiculoService
{
    public async Task<Guid> Adicionar(AdicionarVeiculoCommand cmd) =>
        await mediator.Send(cmd);

    public async Task<bool> Atualizar(AtualizarVeiculoCommand cmd) =>
        await mediator.Send(cmd);

    public async Task<bool> Excluir(Guid id) =>
        await mediator.Send(new RemoverVeiculoCommand(id));

    public async Task<IEnumerable<Veiculo>> ListarTodos() =>
        await mediator.Send(new ListarVeiculosQuery());

    public async Task<Veiculo?> ObterPorId(Guid id) =>
        await mediator.Send(new ObterVeiculoPorIdQuery(id));
}
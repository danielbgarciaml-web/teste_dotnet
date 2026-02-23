using MediatR;
using Veiculos.Application.Commands;
using Veiculos.Application.Queries;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Interfaces;

namespace Veiculos.Application.Handlers;

public class VeiculoHandlers(IVeiculoRepository repository) :
    IRequestHandler<AdicionarVeiculoCommand, Guid>,
    IRequestHandler<RemoverVeiculoCommand, bool>,
    IRequestHandler<AtualizarVeiculoCommand, bool>, // <-- Importante adicionar aqui
    IRequestHandler<ListarVeiculosQuery, IEnumerable<Veiculo>>,
    IRequestHandler<ObterVeiculoPorIdQuery, Veiculo?>
{
    // Handler para Adicionar
    public async Task<Guid> Handle(AdicionarVeiculoCommand request, CancellationToken ct)
    {
        var v = new Veiculo { Descricao = request.Descricao, Marca = request.Marca, Modelo = request.Modelo, Opcionais = request.Opcionais, Valor = request.Valor };
        await repository.AdicionarAsync(v);
        return v.Id;
    }

    // Handler para Remover
    public async Task<bool> Handle(RemoverVeiculoCommand request, CancellationToken ct)
    {
        await repository.RemoverAsync(request.Id);
        return true;
    }

    public async Task<bool> Handle(AtualizarVeiculoCommand request, CancellationToken ct)
    {
        var v = await repository.ObterPorIdAsync(request.Id);
        if (v == null) return false;

        v.Descricao = request.Descricao;
        v.Marca = request.Marca;
        v.Modelo = request.Modelo;
        v.Opcionais = request.Opcionais;
        v.Valor = request.Valor;

        await repository.AtualizarAsync(v);
        return true;
    }

    public async Task<IEnumerable<Veiculo>> Handle(ListarVeiculosQuery req, CancellationToken ct) => await repository.ListarTodosAsync();
    public async Task<Veiculo?> Handle(ObterVeiculoPorIdQuery req, CancellationToken ct) => await repository.ObterPorIdAsync(req.Id);
}
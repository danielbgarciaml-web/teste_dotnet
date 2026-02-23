using MediatR;
using Veiculos.Domain.Enums;

namespace Veiculos.Application.Commands;

public record AdicionarVeiculoCommand(string Descricao, Marca Marca, string Modelo, string? Opcionais, decimal? Valor) : IRequest<Guid>;
public record RemoverVeiculoCommand(Guid Id) : IRequest<bool>;
public record AtualizarVeiculoCommand(Guid Id, string Descricao, Marca Marca, string Modelo, string? Opcionais, decimal? Valor) : IRequest<bool>;
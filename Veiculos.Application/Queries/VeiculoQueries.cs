using MediatR;
using Veiculos.Domain.Entities;

namespace Veiculos.Application.Queries;

public record ListarVeiculosQuery() : IRequest<IEnumerable<Veiculo>>;
public record ObterVeiculoPorIdQuery(Guid Id) : IRequest<Veiculo?>; 
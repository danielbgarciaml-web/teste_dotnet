using Veiculos.Application.Commands;
using Veiculos.Application.Queries;
using Veiculos.Domain.Entities;
namespace Veiculos.Application.Interfaces;

public interface IVeiculoService
{
    Task<Guid> Adicionar(AdicionarVeiculoCommand cmd);
    Task<bool> Atualizar(AtualizarVeiculoCommand cmd);
    Task<bool> Excluir(Guid id);
    Task<IEnumerable<Veiculo>> ListarTodos();
    Task<Veiculo?> ObterPorId(Guid id);
}
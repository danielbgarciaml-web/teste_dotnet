using Veiculos.Domain.Entities;
namespace Veiculos.Domain.Interfaces;

public interface IVeiculoRepository
{
    Task<Veiculo?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Veiculo>> ListarTodosAsync();
    Task AdicionarAsync(Veiculo veiculo);
    Task AtualizarAsync(Veiculo veiculo);
    Task RemoverAsync(Guid id);
}
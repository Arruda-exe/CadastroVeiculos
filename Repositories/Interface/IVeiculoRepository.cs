using CadastroVeiculos.Models;

namespace CadastroVeiculos.Repositories.Interface;

public interface IVeiculoRepository
{
    Task<List<Veiculo>> ObterTodos();
    Task<Veiculo?>ObterPorId(int id);
    Task Adicionar(Veiculo veiculo);
    Task Atualizar(Veiculo veiculo);
    Task Remover(int id);

}


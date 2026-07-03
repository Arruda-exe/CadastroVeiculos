using CadastroVeiculos.Models;

namespace CadastroVeiculos.Repositories.Interface;
//define a interface para o repositório de veículos, fazendo a abstração das operações de persistência de dados
//faz uma promessa de que a classe que implementar essa interface terá que implementar esses métodos
public interface IVeiculoRepository
{
    Task<List<Veiculo>> ObterTodos();
    Task<Veiculo?>ObterPorId(int id);
    Task Adicionar(Veiculo veiculo);
    Task Atualizar(Veiculo veiculo);
    Task Remover(int id);

}


using CadastroVeiculos.Models;

namespace CadastroVeiculos.Repositories.Interface; 

public interface IClienteRepository
{
    Task<List<Cliente>> ObterTodos();
    Task<Cliente?> ObterPorId(int id);
    Task Adicionar(Cliente cliente);
    Task Atualizar(Cliente cliente);
    Task Remover(int id);

}
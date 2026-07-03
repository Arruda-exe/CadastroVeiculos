using CadastroVeiculos.Data;
using CadastroVeiculos.Models;
using CadastroVeiculos.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
//implementa a interface IVeiculoRepository, fornecendo a implementação concreta dos métodos definidos na interface
//cumpre a promessa de que a classe terá que implementar os métodos que foram definidos na interface
namespace CadastroVeiculos.Repositories; 

public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;

    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Veiculo>> ObterTodos()
    {
        return await _context.Veiculos.ToListAsync();
    }

    public async Task<Veiculo?> ObterPorId(int id)
    {
        return await _context.Veiculos.FindAsync(id);
    }
    
    public async Task Adicionar(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();


    }
    
    public async Task Atualizar(Veiculo veiculo)

    {
        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync();

    }

    public async Task Remover(int id)
    {
        var veiculo = await ObterPorId(id);
        if (veiculo != null)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
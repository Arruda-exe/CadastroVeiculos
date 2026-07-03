using CadastroVeiculos.Data;
using CadastroVeiculos.Models;
using CadastroVeiculos.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroVeiculos.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObterTodos()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> ObterPorId(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Adicionar(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Cliente cliente)
    
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(int id)
    {
        var cliente = await ObterPorId(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }

}
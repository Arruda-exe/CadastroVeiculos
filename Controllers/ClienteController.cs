using Microsoft.AspNetCore.Mvc;
using CadastroVeiculos.Models;
using CadastroVeiculos.Repositories.Interface;

namespace CadastroVeiculos.Controllers;

[ApiController]
[Route ("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repositories;

    public ClienteController (IClienteRepository repositories)
    {
        _repositories = repositories;
    }
    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> ObterTodos()

    {
        var clientes = await _repositories.ObterTodos();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> ObterPorId(int id)
    {
        var Cliente = await _repositories.ObterPorId(id);
        if (Cliente == null)
        {
            return NotFound();
        }
        return Ok(Cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Cliente cliente)
    {
        await _repositories.Adicionar(cliente);
        return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }
        var ClienteExistente = await _repositories.ObterPorId(id);
        if (ClienteExistente == null)
        {
            return NotFound();
        }

        await _repositories.Atualizar(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var cliente = await _repositories.ObterPorId(id);
        if (cliente == null)
        {
            return NotFound();
        }

        await _repositories.Remover(id);
        return NoContent();
    }
}
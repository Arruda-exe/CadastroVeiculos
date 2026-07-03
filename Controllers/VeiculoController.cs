using Microsoft.AspNetCore.Mvc;
using CadastroVeiculos.Models;
using CadastroVeiculos.Repositories.Interface;

namespace CadastroVeiculos.Controllers;

[ApiController]
[Route ("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoRepository _repositories; 

    public VeiculoController (IVeiculoRepository repositories)
    {
        _repositories = repositories;
    }

    [HttpGet]
    public async Task<ActionResult<List<Veiculo>>> ObterTodos()
    {
        var veiculos = await _repositories.ObterTodos();
        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var veiculo = await _repositories.ObterPorId(id);
        if (veiculo == null)
        {
            return NotFound();
        }
        return Ok(veiculo);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Veiculo veiculo)
    {
        await _repositories.Adicionar(veiculo);
        return CreatedAtAction(nameof(ObterPorId), new {id = veiculo.Id}, veiculo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id)
            return BadRequest();

        var veiculoExistente = await _repositories.ObterPorId(id);
        if (veiculoExistente == null)
        {
            return NotFound();
        }
        await _repositories.Atualizar(veiculo);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var veiculo = await _repositories.ObterPorId(id);
        if (veiculo == null)
            return NotFound();

        await _repositories.Remover(id);
        return NoContent();
        
    }

}

namespace CadastroVeiculos.Models;


public class Cliente

{
    public int Id { get; set; } = 0;

    public required string Email {get; set;}

    public required  string Cpf {get; set;}

    public required string Telefone {get; set;}
}
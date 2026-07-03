namespace CadastroVeiculos.Models; 

public class Veiculo
{
    public int Id {get; set;}
    public required string Marca {get; set;}
    public required string Modelo {get; set;}
    public int Ano {get; set;}
    public decimal Preco {get; set;}
}
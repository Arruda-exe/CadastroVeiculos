using Microsoft.EntityFrameworkCore;
using CadastroVeiculos.Models;
//faz a trancrição do banco de dados para o modelo de veiculo
namespace CadastroVeiculos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Cliente> Clientes {get; set;}

    }
}
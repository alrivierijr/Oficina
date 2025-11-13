using Microsoft.EntityFrameworkCore;


namespace Oficina.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        // Exemplo de entidade
        public DbSet<Cliente> Clientes { get; set; } = default!;

    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }


}

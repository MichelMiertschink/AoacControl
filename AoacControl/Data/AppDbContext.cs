using AoacControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<UniaoParoquial> UnioesParoquiais { get; set; }
        public DbSet<Paroquia> Paroquias { get; set; }
        public DbSet<Comunidade> Comunidades { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<Associado> Associados { get; set; }
    }

    
}

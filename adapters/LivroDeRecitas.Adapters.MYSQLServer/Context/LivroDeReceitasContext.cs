using LivroDeReceitas.Core.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LivroDeRecitas.Adapters.MYSQLServer.Context
{
    public class LivroDeReceitasContext : DbContext
    {
        public LivroDeReceitasContext(DbContextOptions<LivroDeReceitasContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroDeReceitasContext).Assembly);
        }
    }
}

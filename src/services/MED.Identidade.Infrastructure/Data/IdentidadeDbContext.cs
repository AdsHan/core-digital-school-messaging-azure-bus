using MED.Identidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MED.Identidade.Infrastructure.Data
{
    public class IdentidadeDbContext : DbContext
    {

        public IdentidadeDbContext()
        {

        }

        public IdentidadeDbContext(DbContextOptions<IdentidadeDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

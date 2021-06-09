using MED.Identidade.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MED.Identidade.Infrastructure.Data
{
    public class IdentidadeDbContext : IdentityDbContext<UsuarioModel>
    {

        public IdentidadeDbContext()
        {

        }

        public IdentidadeDbContext(DbContextOptions<IdentidadeDbContext> options) : base(options)
        {

        }

        public DbSet<TokenModel> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}


using MED.Aluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MED.Aluno.Infrastructure.Data
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {

        }

        public DbSet<EscolaModel> Escolas { get; set; }
        public DbSet<EscolaModel> Turma { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<ResponsavelModel> Responsaveis { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ObservacaoModel> Observacoes { get; set; }
        public DbSet<AlunoResponsavelModel> AlunoResponsavel { get; set; }
        public DbSet<ResumoDiaModel> ResumosDias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

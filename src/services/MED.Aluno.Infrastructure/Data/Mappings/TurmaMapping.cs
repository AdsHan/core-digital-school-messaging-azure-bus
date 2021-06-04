using MED.Aluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class TurmaMapping : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Turma : Observacao
            builder.HasOne(t => t.Observacao).WithOne();

            // N : 1 => Turma : Escola
            builder.HasOne(t => t.Escola)
                .WithMany(e => e.Turmas)
                .OnDelete(DeleteBehavior.Restrict);

            // 1 : N  => Turma : Aluno
            builder.HasMany(t => t.Alunos)
                .WithOne(a => a.Turma)
                .HasForeignKey(a => a.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Turmas");

        }
    }
}

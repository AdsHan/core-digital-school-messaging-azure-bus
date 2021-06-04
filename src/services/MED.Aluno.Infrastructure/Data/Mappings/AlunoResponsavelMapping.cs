using MED.Aluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class AlunoResponsavelMapping : IEntityTypeConfiguration<AlunoResponsavelModel>
    {
        public void Configure(EntityTypeBuilder<AlunoResponsavelModel> builder)
        {

            builder.HasKey(a => new { a.AlunoId, a.ResponsavelId });

            // N : N => Aluno : Responsavel
            builder
                .HasOne(a => a.Aluno)
                .WithMany(a => a.AlunosResponsaveis)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Responsavel)
                .WithMany(a => a.AlunosResponsaveis)
                .HasForeignKey(a => a.ResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("AlunosResponsaveis");

        }
    }
}

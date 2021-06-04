using MED.Aluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class ResumoDiaMapping : IEntityTypeConfiguration<ResumoDiaModel>
    {
        public void Configure(EntityTypeBuilder<ResumoDiaModel> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Texto)
                .IsRequired()
                .HasColumnType("varchar(8000)");

            // N : 1 => Resumo Dia : Aluno
            builder.HasOne(r => r.Aluno)
                .WithMany(r => r.Resumos)
                .HasForeignKey(r => r.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ResumosDias");
        }
    }
}

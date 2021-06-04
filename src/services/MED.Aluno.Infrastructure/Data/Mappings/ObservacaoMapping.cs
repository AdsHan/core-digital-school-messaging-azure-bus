using MED.Aluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class ObservacaoConfigurations : IEntityTypeConfiguration<ObservacaoModel>
    {
        public void Configure(EntityTypeBuilder<ObservacaoModel> builder)
        {

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Texto)
                .IsRequired()
                .HasColumnType("varchar(8000)");

            builder.ToTable("Observacoes");

        }
    }
}

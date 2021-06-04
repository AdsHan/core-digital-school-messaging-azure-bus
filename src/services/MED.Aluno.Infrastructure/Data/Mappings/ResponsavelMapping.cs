using MED.Aluno.Domain.Entities;
using MED.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class ResponsavelMapping : IEntityTypeConfiguration<ResponsavelModel>
    {
        public void Configure(EntityTypeBuilder<ResponsavelModel> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(r => r.Rg, tf =>
            {
                tf.Property(r => r.Numero)
                    .HasMaxLength(Rg.RgMaxLength)
                    .HasColumnName("Rg")
                    .HasColumnType($"varchar({Rg.RgMaxLength})");
            });

            builder.OwnsOne(r => r.Cpf, tf =>
            {
                tf.Property(r => r.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(r => r.Email, tf =>
            {
                tf.Property(r => r.Endereco)
                    .IsRequired()
                    .HasMaxLength(Email.EnderecoMaxLength)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.OwnsOne(r => r.Telefone, tf =>
            {
                tf.Property(r => r.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            builder.OwnsOne(r => r.Celular, tf =>
            {
                tf.Property(r => r.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Celular")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            // 1 : 1 => Responsavel : Observacao
            builder.HasOne(r => r.Observacao).WithOne();

            builder.ToTable("Responsaveis");
        }
    }
}

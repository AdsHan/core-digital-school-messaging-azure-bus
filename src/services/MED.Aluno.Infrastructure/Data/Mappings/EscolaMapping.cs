using MED.Aluno.Domain.Entities;
using MED.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MED.Aluno.Infrastructure.Data.Mapping
{
    public class EscolaMapping : IEntityTypeConfiguration<EscolaModel>
    {
        public void Configure(EntityTypeBuilder<EscolaModel> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.OwnsOne(e => e.Cnpj, tf =>
            {
                tf.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(Cnpj.CnpjMaxLength)
                    .HasColumnName("Cpnj")
                    .HasColumnType($"varchar({Cnpj.CnpjMaxLength})");
            });

            builder.OwnsOne(e => e.Email, tf =>
            {
                tf.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(Email.EnderecoMaxLength)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.OwnsOne(e => e.Telefone, tf =>
            {
                tf.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            builder.OwnsOne(e => e.Celular, tf =>
            {
                tf.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Celular")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            // 1 : 1 => Escola : Endereco
            builder.HasOne(e => e.Endereco).WithOne();

            // 1 : 1 => Escola : Observacao
            builder.HasOne(e => e.Endereco).WithOne();

            // 1 : N => Escola : Turma
            builder.HasMany(e => e.Turmas)
                .WithOne(t => t.Escola)
                .HasForeignKey(t => t.EscolaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Escolas");

        }
    }
}

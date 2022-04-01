using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.Sobrenome)
                   .HasColumnName("Sobrenome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .HasColumnName("Cpf")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(14)
                   .IsRequired();
        }
    }
}
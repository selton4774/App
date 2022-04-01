using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class RegistroPontoMapping : IEntityTypeConfiguration<RegistroPonto>
    {
        public void Configure(EntityTypeBuilder<RegistroPonto> builder)
        {
            builder.ToTable("RegistroPonto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Tempo)
                   .HasColumnName("Tempo")
                   .HasColumnType("DATETIME")
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.RegistroPontos)
                   .HasForeignKey(x => x.IdFuncionario);
        }
    }
}
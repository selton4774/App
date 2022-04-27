using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class ContratoMapping : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("Contrato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.DataInicio)
                   .HasColumnName("DataInicio")
                   .HasColumnType("DATETIME")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.DataFim)
                   .HasColumnName("DataFim")
                   .HasColumnType("DATETIME");

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.Contratos)
                   .HasForeignKey(x => x.IdFuncionario)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ModalidadeContrato)
                   .WithMany(x => x.Contratos)
                   .HasForeignKey(x => x.IdModalidadeContrato)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Expediente)
                   .WithMany(x => x.Contratos)
                   .HasForeignKey(x => x.IdExpediente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Cargo)
                   .WithMany(x => x.Contratos)
                   .HasForeignKey(x => x.IdCargo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
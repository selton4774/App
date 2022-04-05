using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class ModalidadeContratoMapping : IEntityTypeConfiguration<ModalidadeContrato>
    {
        public void Configure(EntityTypeBuilder<ModalidadeContrato> builder)
        {
            builder.ToTable("ModalidadeContrato");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80)
                   .IsRequired();
        }
    }
}
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class ModalidadeHoraExtraMapping : IEntityTypeConfiguration<ModalidadeHoraExtra>
    {
        public void Configure(EntityTypeBuilder<ModalidadeHoraExtra> builder)
        {
            builder.ToTable("ModalidadeHoraExtra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Descricao)
                   .HasColumnName("Descricao")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(x => x.Valor)
                   .IsRequired()
                   .HasColumnName("Valor")
                   .HasColumnType("FLOAT");

        }
    }
}
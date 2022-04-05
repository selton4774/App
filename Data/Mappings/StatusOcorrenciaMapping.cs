using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class StatusOcorrenciaMapping : IEntityTypeConfiguration<StatusOcorrencia>
    {
        public void Configure(EntityTypeBuilder<StatusOcorrencia> builder)
        {
            builder.ToTable("StatusOcorrencia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasColumnName("Descricao")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(120)
                   .IsRequired();
        }
    }
}
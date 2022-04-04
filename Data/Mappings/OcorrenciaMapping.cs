using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("Ocorrencia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                   .HasColumnName("Descricao")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(120);

            builder.Property(x => x.Data)
                   .HasColumnName("Data")
                   .HasColumnType("DATETIME")
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            builder.HasOne(x => x.TipoOcorrencia)
                   .WithMany(x => x.Ocorrencias)
                   .HasForeignKey(x => x.IdTipoOcorrencia);

            builder.HasOne(x => x.StatusOcorrencia)
                   .WithMany(x => x.Ocorrencias)
                   .HasForeignKey(x => x.IdStatusOcorrencia);

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.Ocorrencias)
                   .HasForeignKey(x => x.IdFuncionario);

        }
    }
}
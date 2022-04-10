using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mappings
{
    public class HoraExtraMapping : IEntityTypeConfiguration<HoraExtra>
    {
        public void Configure(EntityTypeBuilder<HoraExtra> builder)
        {
            builder.ToTable("HoraExtra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.QtdUsada)
                   .HasColumnName("QtdUsada")
                   .HasColumnType("INT")
                   .IsRequired();

            builder.Property(x => x.DataUso)
                   .HasColumnName("DataUso")
                   .HasColumnType("DATETIME")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Tipo)
                   .WithMany(x => x.HorasExtras)
                   .HasForeignKey(x => x.IdTipo);

            builder.HasOne(x => x.ModalidadeHoraExtra)
                   .WithMany(x => x.HorasExtras)
                   .HasForeignKey(x => x.IdModalidadeHoraExtra);

            builder.HasOne(x => x.Funcionario)
                   .WithMany(x => x.HorasExtras)
                   .HasForeignKey(x => x.IdFuncionario);

        }
    }
}
using App.Data.Mappings;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Expediente> expedientes { get; set; }
        public DbSet<ModalidadeContrato> modalidadeContratos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=App;User ID =sa;Password=Es101010!");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoMapping());
            modelBuilder.ApplyConfiguration(new ExpedienteMapping());
            modelBuilder.ApplyConfiguration(new ModalidadeContratoMapping());
            modelBuilder.ApplyConfiguration(new ModalidadeHoraExtraMapping());
            modelBuilder.ApplyConfiguration(new TipoMapping());
            modelBuilder.ApplyConfiguration(new TipoOcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new StatusOcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new RegistroPontoMapping());
            modelBuilder.ApplyConfiguration(new HoraExtraMapping());
            modelBuilder.ApplyConfiguration(new OcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new ContratoMapping());
        }
    }
}
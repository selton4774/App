using App.Data.Mappings;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        // dotnet add package Microsoft.EntityFrameworkCore --version 5.0
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0
        // dotnet add package EPPlus --version 5.0

        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Expediente> expedientes { get; set; }
        public DbSet<ModalidadeContrato> modalidadeContratos { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<RegistroPonto> registroPontos { get; set; }
        public DbSet<Contrato> contratos { get; set; }
        public DbSet<Tipo> tipos { get; set; }
        public DbSet<ModalidadeHoraExtra> modalidadeHoraExtras { get; set; }
        public DbSet<HoraExtra> horaExtras { get; set; }
        public DbSet<TipoOcorrencia> tipoOcorrencias { get; set; }
        public DbSet<StatusOcorrencia> statusOcorrencias { get; set; }
        public DbSet<Ocorrencia> ocorrencias { get; set; }

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
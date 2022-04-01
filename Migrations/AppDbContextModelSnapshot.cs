﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("App.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("NomeCargo");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("App.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataFim");

                    b.Property<DateTime>("DataInicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataInicio")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdExpediente")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdModalidadeContrato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdExpediente");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdModalidadeContrato");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("App.Models.Expediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INT")
                        .HasColumnName("CargaHoraria");

                    b.HasKey("Id");

                    b.ToTable("Expediente");
                });

            modelBuilder.Entity("App.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("NVARCHAR(14)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Sobrenome");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("App.Models.HoraExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataUso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataUso")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdModalidadeHoraExtra")
                        .HasColumnType("int");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<int>("QtdUsada")
                        .HasColumnType("INT")
                        .HasColumnName("QtdUsada");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdModalidadeHoraExtra");

                    b.HasIndex("IdTipo");

                    b.ToTable("HoraExtra");
                });

            modelBuilder.Entity("App.Models.ModalidadeContrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("ModalidadeContrato");
                });

            modelBuilder.Entity("App.Models.ModalidadeHoraExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR(120)")
                        .HasColumnName("Descricao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(38,17)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("ModalidadeHoraExtra");
                });

            modelBuilder.Entity("App.Models.Ocorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Data")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR(120)")
                        .HasColumnName("Descricao");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdStatusOcorrencia")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoOcorrencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario");

                    b.HasIndex("IdStatusOcorrencia");

                    b.HasIndex("IdTipoOcorrencia");

                    b.ToTable("Ocorrencia");
                });

            modelBuilder.Entity("App.Models.RegistroPonto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tempo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Tempo")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("RegistroPonto");
                });

            modelBuilder.Entity("App.Models.StatusOcorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR(120)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("StatusOcorrencia");
                });

            modelBuilder.Entity("App.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR(120)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("App.Models.TipoOcorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoOcorrencia");
                });

            modelBuilder.Entity("App.Models.Contrato", b =>
                {
                    b.HasOne("App.Models.Cargo", "Cargo")
                        .WithMany("Contratos")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Expediente", "Expediente")
                        .WithMany("Contratos")
                        .HasForeignKey("IdExpediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Funcionario", "Funcionario")
                        .WithMany("Contratos")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.ModalidadeContrato", "ModalidadeContrato")
                        .WithMany("Contratos")
                        .HasForeignKey("IdModalidadeContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Expediente");

                    b.Navigation("Funcionario");

                    b.Navigation("ModalidadeContrato");
                });

            modelBuilder.Entity("App.Models.HoraExtra", b =>
                {
                    b.HasOne("App.Models.Funcionario", "Funcionario")
                        .WithMany("HoraExtras")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.ModalidadeHoraExtra", "ModalidadeHoraExtra")
                        .WithMany("HoraExtras")
                        .HasForeignKey("IdModalidadeHoraExtra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Tipo", "Tipo")
                        .WithMany("HoraExtras")
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("ModalidadeHoraExtra");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("App.Models.Ocorrencia", b =>
                {
                    b.HasOne("App.Models.Funcionario", "Funcionario")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.StatusOcorrencia", "StatusOcorrencia")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdStatusOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.TipoOcorrencia", "TipoOcorrencia")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdTipoOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("StatusOcorrencia");

                    b.Navigation("TipoOcorrencia");
                });

            modelBuilder.Entity("App.Models.RegistroPonto", b =>
                {
                    b.HasOne("App.Models.Funcionario", "Funcionario")
                        .WithMany("RegistroPontos")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("App.Models.Cargo", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("App.Models.Expediente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("App.Models.Funcionario", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("HoraExtras");

                    b.Navigation("Ocorrencias");

                    b.Navigation("RegistroPontos");
                });

            modelBuilder.Entity("App.Models.ModalidadeContrato", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("App.Models.ModalidadeHoraExtra", b =>
                {
                    b.Navigation("HoraExtras");
                });

            modelBuilder.Entity("App.Models.StatusOcorrencia", b =>
                {
                    b.Navigation("Ocorrencias");
                });

            modelBuilder.Entity("App.Models.Tipo", b =>
                {
                    b.Navigation("HoraExtras");
                });

            modelBuilder.Entity("App.Models.TipoOcorrencia", b =>
                {
                    b.Navigation("Ocorrencias");
                });
#pragma warning restore 612, 618
        }
    }
}

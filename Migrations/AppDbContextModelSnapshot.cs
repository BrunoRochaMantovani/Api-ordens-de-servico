﻿// <auto-generated />
using System;
using API_ORDEM_SERVICO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIORDEMSERVICO.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Finalizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("valorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Finalizacoes");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Ordem_De_Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescProblema")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("Equipamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FinalizacaoId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FinalizacaoId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Ordems_De_servico");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Atividade")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Tecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("OrdemServicos", b =>
                {
                    b.Property<int>("cod_ordem")
                        .HasColumnType("int");

                    b.Property<int>("cod_servico")
                        .HasColumnType("int");

                    b.HasKey("cod_ordem", "cod_servico");

                    b.HasIndex("cod_servico");

                    b.ToTable("OrdemServicos");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Ordem_De_Servico", b =>
                {
                    b.HasOne("API_ORDEM_SERVICO.Models.Cliente", "Cliente")
                        .WithMany("Ordem_De_Servicos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_ORDEM_SERVICO.Models.Finalizacao", "Finalizacao")
                        .WithMany()
                        .HasForeignKey("FinalizacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_ORDEM_SERVICO.Models.Tecnico", "Tecnico")
                        .WithMany("Ordem_De_Servico")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Finalizacao");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("OrdemServicos", b =>
                {
                    b.HasOne("API_ORDEM_SERVICO.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("cod_ordem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_cod_ordem");

                    b.HasOne("API_ORDEM_SERVICO.Models.Ordem_De_Servico", null)
                        .WithMany()
                        .HasForeignKey("cod_servico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_cod_servico");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Cliente", b =>
                {
                    b.Navigation("Ordem_De_Servicos");
                });

            modelBuilder.Entity("API_ORDEM_SERVICO.Models.Tecnico", b =>
                {
                    b.Navigation("Ordem_De_Servico");
                });
#pragma warning restore 612, 618
        }
    }
}

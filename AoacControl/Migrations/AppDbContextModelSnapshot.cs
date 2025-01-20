﻿// <auto-generated />
using System;
using AoacControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AoacControl.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AoacControl.Models.Associado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ComunidadeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Voz")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ComunidadeID");

                    b.ToTable("Associados");
                });

            modelBuilder.Entity("AoacControl.Models.Comunidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ParoquiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ParoquiaId");

                    b.ToTable("Comunidades");
                });

            modelBuilder.Entity("AoacControl.Models.Instrumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssociadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FonteDoacao")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<int>("Patrimonio")
                        .HasColumnType("int");

                    b.Property<int>("TipoInstrumento")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("ValorInstrumento")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("AssociadoId")
                        .IsUnique();

                    b.HasIndex("MarcaId");

                    b.HasIndex("Patrimonio")
                        .IsUnique();

                    b.ToTable("Instrumentos");
                });

            modelBuilder.Entity("AoacControl.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("AoacControl.Models.Paroquia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniaoParoquialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("UniaoParoquialId");

                    b.ToTable("Paroquias");
                });

            modelBuilder.Entity("AoacControl.Models.UniaoParoquial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("UnioesParoquiais");
                });

            modelBuilder.Entity("AoacControl.Models.Associado", b =>
                {
                    b.HasOne("AoacControl.Models.Comunidade", "Comunidade")
                        .WithMany()
                        .HasForeignKey("ComunidadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comunidade");
                });

            modelBuilder.Entity("AoacControl.Models.Comunidade", b =>
                {
                    b.HasOne("AoacControl.Models.Paroquia", "Paroquia")
                        .WithMany("Comunidade")
                        .HasForeignKey("ParoquiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paroquia");
                });

            modelBuilder.Entity("AoacControl.Models.Instrumento", b =>
                {
                    b.HasOne("AoacControl.Models.Associado", "Associado")
                        .WithOne("InstrumentoID")
                        .HasForeignKey("AoacControl.Models.Instrumento", "AssociadoId");

                    b.HasOne("AoacControl.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Associado");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("AoacControl.Models.Paroquia", b =>
                {
                    b.HasOne("AoacControl.Models.UniaoParoquial", "UniaoParoquial")
                        .WithMany("Paroquias")
                        .HasForeignKey("UniaoParoquialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UniaoParoquial");
                });

            modelBuilder.Entity("AoacControl.Models.Associado", b =>
                {
                    b.Navigation("InstrumentoID");
                });

            modelBuilder.Entity("AoacControl.Models.Paroquia", b =>
                {
                    b.Navigation("Comunidade");
                });

            modelBuilder.Entity("AoacControl.Models.UniaoParoquial", b =>
                {
                    b.Navigation("Paroquias");
                });
#pragma warning restore 612, 618
        }
    }
}

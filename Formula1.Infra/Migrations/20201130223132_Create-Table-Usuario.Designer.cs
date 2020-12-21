﻿// <auto-generated />
using System;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Formula1.Infra.Migrations
{
    [DbContext(typeof(F1Db))]
    [Migration("20201130223132_Create-Table-Usuario")]
    partial class CreateTableUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Formula1.Data.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PilotoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temporada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("PilotoId");

                    b.HasIndex("Temporada");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Corrida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Circuito")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataHoraBrasil")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeGrandePremio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Temporada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Temporada");

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CorRgb")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Formula1.Data.Entities.EquipeTemporada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Posicao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temporada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("EquipesTemporada");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Piloto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeGuerra")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroCarro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaisOrigem")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pilotos");
                });

            modelBuilder.Entity("Formula1.Data.Entities.PilotoTemporada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PilotoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Posicao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temporada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PilotoId");

                    b.ToTable("PilotosTemporada");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Punicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int?>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PilotoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temporada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("PilotoId");

                    b.HasIndex("Temporada");

                    b.ToTable("Punicoes");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Resultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorridaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DNF")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PilotoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PontoExtra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosicaoChegada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PosicaoLargada")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CorridaId");

                    b.HasIndex("EquipeId");

                    b.HasIndex("PilotoId");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Contrato", b =>
                {
                    b.HasOne("Formula1.Data.Entities.Equipe", "Equipe")
                        .WithMany("Contratos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Formula1.Data.Entities.Piloto", "Piloto")
                        .WithMany("Contratos")
                        .HasForeignKey("PilotoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Formula1.Data.Entities.EquipeTemporada", b =>
                {
                    b.HasOne("Formula1.Data.Entities.Equipe", "Equipe")
                        .WithMany("Temporadas")
                        .HasForeignKey("EquipeId");
                });

            modelBuilder.Entity("Formula1.Data.Entities.PilotoTemporada", b =>
                {
                    b.HasOne("Formula1.Data.Entities.Piloto", "Piloto")
                        .WithMany("Temporadas")
                        .HasForeignKey("PilotoId");
                });

            modelBuilder.Entity("Formula1.Data.Entities.Punicao", b =>
                {
                    b.HasOne("Formula1.Data.Entities.Equipe", "Equipe")
                        .WithMany("Punicoes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Formula1.Data.Entities.Piloto", "Piloto")
                        .WithMany("Punicoes")
                        .HasForeignKey("PilotoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Formula1.Data.Entities.Resultado", b =>
                {
                    b.HasOne("Formula1.Data.Entities.Corrida", "Corrida")
                        .WithMany("Resultados")
                        .HasForeignKey("CorridaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Formula1.Data.Entities.Equipe", "Equipe")
                        .WithMany("Resultados")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Formula1.Data.Entities.Piloto", "Piloto")
                        .WithMany("Resultados")
                        .HasForeignKey("PilotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

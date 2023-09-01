﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Controle_de_Alienígenas.Data;

#nullable disable

namespace Sistema_de_Controle_de_Alienígenas.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230830183141_planeta_ENxuto")]
    partial class planeta_ENxuto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("Corpo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaNaTerra")
                        .HasColumnType("bit");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanetaID");

                    b.ToTable("Aliens");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.AlienPoderModel", b =>
                {
                    b.Property<int>("AlienId")
                        .HasColumnType("int");

                    b.Property<int>("PoderId")
                        .HasColumnType("int");

                    b.HasKey("AlienId", "PoderId");

                    b.HasIndex("PoderId");

                    b.ToTable("AlienPoder");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.PlanetaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planetas");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.PoderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Poderes");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.RegistroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlienId")
                        .HasColumnType("int");

                    b.Property<int?>("AlienModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlienId");

                    b.HasIndex("AlienModelId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", b =>
                {
                    b.HasOne("Sistema_de_Controle_de_Alienígenas.Models.PlanetaModel", "Planeta")
                        .WithMany()
                        .HasForeignKey("PlanetaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planeta");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.AlienPoderModel", b =>
                {
                    b.HasOne("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", "Alien")
                        .WithMany("AlienPoderes")
                        .HasForeignKey("AlienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_de_Controle_de_Alienígenas.Models.PoderModel", "Poder")
                        .WithMany("AlienPoderes")
                        .HasForeignKey("PoderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alien");

                    b.Navigation("Poder");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.RegistroModel", b =>
                {
                    b.HasOne("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", "Alien")
                        .WithMany()
                        .HasForeignKey("AlienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", null)
                        .WithMany("Registro")
                        .HasForeignKey("AlienModelId");

                    b.Navigation("Alien");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.AlienModel", b =>
                {
                    b.Navigation("AlienPoderes");

                    b.Navigation("Registro");
                });

            modelBuilder.Entity("Sistema_de_Controle_de_Alienígenas.Models.PoderModel", b =>
                {
                    b.Navigation("AlienPoderes");
                });
#pragma warning restore 612, 618
        }
    }
}

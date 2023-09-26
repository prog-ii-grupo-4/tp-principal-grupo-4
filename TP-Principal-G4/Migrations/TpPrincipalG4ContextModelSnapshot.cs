﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_Principal_G4;

#nullable disable

namespace TP_Principal_G4.Migrations
{
    [DbContext(typeof(TpPrincipalG4Context))]
    partial class TpPrincipalG4ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TP_Principal_G4.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaDeIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Id_Raza")
                        .HasColumnType("int");

                    b.Property<int>("Id_Refugio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Raza");

                    b.HasIndex("Id_Refugio");

                    b.ToTable("Animales");
                });

            modelBuilder.Entity("TP_Principal_G4.Entities.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Razas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "San bernardo"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Labrador retriever"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Gato persa"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Gato siamés"
                        });
                });

            modelBuilder.Entity("TP_Principal_G4.Entities.Refugio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoDelResponsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDelResponsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Refugios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApellidoDelResponsable = "Pérez",
                            Nombre = "Santuario animal",
                            NombreDelResponsable = "Jorge",
                            RazonSocial = "Santuario animal S.A."
                        });
                });

            modelBuilder.Entity("TP_Principal_G4.Entities.Animal", b =>
                {
                    b.HasOne("TP_Principal_G4.Entities.Raza", "Raza")
                        .WithMany("Animales")
                        .HasForeignKey("Id_Raza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP_Principal_G4.Entities.Refugio", "Refugio")
                        .WithMany("Animales")
                        .HasForeignKey("Id_Refugio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Raza");

                    b.Navigation("Refugio");
                });

            modelBuilder.Entity("TP_Principal_G4.Entities.Raza", b =>
                {
                    b.Navigation("Animales");
                });

            modelBuilder.Entity("TP_Principal_G4.Entities.Refugio", b =>
                {
                    b.Navigation("Animales");
                });
#pragma warning restore 612, 618
        }
    }
}

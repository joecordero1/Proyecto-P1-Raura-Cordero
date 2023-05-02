﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_P1_Raura_Cordero.Data;

#nullable disable

namespace Proyecto_P1_Raura_Cordero.Migrations
{
    [DbContext(typeof(Proyecto_P1_Raura_CorderoContext))]
    [Migration("20230502011959_inicio")]
    partial class inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Pelicula", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPelicula"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdResena")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResenaIdResena")
                        .HasColumnType("int");

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.HasKey("IdPelicula");

                    b.HasIndex("ResenaIdResena");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Resena", b =>
                {
                    b.Property<int>("IdResena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResena"));

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResena");

                    b.ToTable("Resena");
                });

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Usuario", b =>
                {
                    b.Property<int>("Cedula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cedula"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdResena")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResenaIdResena")
                        .HasColumnType("int");

                    b.HasKey("Cedula");

                    b.HasIndex("ResenaIdResena");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Pelicula", b =>
                {
                    b.HasOne("Proyecto_P1_Raura_Cordero.Models.Resena", "Resena")
                        .WithMany("Resenas")
                        .HasForeignKey("ResenaIdResena");

                    b.Navigation("Resena");
                });

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Usuario", b =>
                {
                    b.HasOne("Proyecto_P1_Raura_Cordero.Models.Resena", "Resena")
                        .WithMany("ResenaUsuario")
                        .HasForeignKey("ResenaIdResena");

                    b.Navigation("Resena");
                });

            modelBuilder.Entity("Proyecto_P1_Raura_Cordero.Models.Resena", b =>
                {
                    b.Navigation("ResenaUsuario");

                    b.Navigation("Resenas");
                });
#pragma warning restore 612, 618
        }
    }
}

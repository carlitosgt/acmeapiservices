﻿// <auto-generated />
using System;
using APIsurveys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIsurveys.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220401233208_Modificacion")]
    partial class Modificacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIsurveys.Modelos.CamposEncuesta", b =>
                {
                    b.Property<int>("IdCampoEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EncuestaIdEncuesta")
                        .HasColumnType("int");

                    b.Property<bool>("EsRequerido")
                        .HasColumnType("bit");

                    b.Property<int?>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<string>("NombreCampo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Respuesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TituloCampo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoCampo")
                        .HasColumnType("int");

                    b.HasKey("IdCampoEncuesta");

                    b.HasIndex("EncuestaIdEncuesta");

                    b.ToTable("CamposEncuesta");
                });

            modelBuilder.Entity("APIsurveys.Modelos.Encuesta", b =>
                {
                    b.Property<int>("IdEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("LinkEncuesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEncuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdEncuesta");

                    b.HasIndex("UserId");

                    b.ToTable("Encuestas");
                });

            modelBuilder.Entity("APIsurveys.Modelos.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIsurveys.Modelos.CamposEncuesta", b =>
                {
                    b.HasOne("APIsurveys.Modelos.Encuesta", "Encuesta")
                        .WithMany()
                        .HasForeignKey("EncuestaIdEncuesta");

                    b.Navigation("Encuesta");
                });

            modelBuilder.Entity("APIsurveys.Modelos.Encuesta", b =>
                {
                    b.HasOne("APIsurveys.Modelos.User", "User")
                        .WithMany("Encuestas")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIsurveys.Modelos.User", b =>
                {
                    b.Navigation("Encuestas");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using HospiEnCasa.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospiEnCasa.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Enfermera", b =>
                {
                    b.Property<int?>("IdEnfermera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEnfermera"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("HorasLaborales")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEnfermera");

                    b.ToTable("Enfermeras");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.FamiliarDesignado", b =>
                {
                    b.Property<int?>("IdFamiliarDesignado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdFamiliarDesignado"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentesco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFamiliarDesignado");

                    b.ToTable("FamiliaresDesignados");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.Property<int>("IdHistoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHistoria"), 1L, 1);

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHistoria");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Medico", b =>
                {
                    b.Property<int?>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdMedico"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroRethus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedico");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.Property<int?>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdPaciente"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("IdEnfermera")
                        .HasColumnType("int");

                    b.Property<int>("IdFamiliarDesignado")
                        .HasColumnType("int");

                    b.Property<int>("IdHistoria")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<float?>("Latitud")
                        .HasColumnType("real");

                    b.Property<float?>("Longitud")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdEnfermera");

                    b.HasIndex("IdFamiliarDesignado");

                    b.HasIndex("IdHistoria");

                    b.HasIndex("IdMedico");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.Property<int>("IdSignoVital")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Signo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("IdSignoVital");

                    b.ToTable("SignosVitales");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.Property<int>("IdSugerenciaCuidado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSugerenciaCuidado"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaIdHistoria")
                        .HasColumnType("int");

                    b.HasKey("IdSugerenciaCuidado");

                    b.HasIndex("HistoriaIdHistoria");

                    b.ToTable("SugerenciasCuidado");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Enfermera", "Enfermera")
                        .WithMany()
                        .HasForeignKey("IdEnfermera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospiEnCasa.App.Dominio.FamiliarDesignado", "FamiliarDesignado")
                        .WithMany()
                        .HasForeignKey("IdFamiliarDesignado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospiEnCasa.App.Dominio.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("IdHistoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospiEnCasa.App.Dominio.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enfermera");

                    b.Navigation("FamiliarDesignado");

                    b.Navigation("Historia");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Paciente", null)
                        .WithMany("SignoVitales")
                        .HasForeignKey("IdSignoVital")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Historia", null)
                        .WithMany("Sugerencias")
                        .HasForeignKey("HistoriaIdHistoria");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.Navigation("Sugerencias");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.Navigation("SignoVitales");
                });
#pragma warning restore 612, 618
        }
    }
}

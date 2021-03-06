using System;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : IdentityDbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<FamiliarDesignado> FamiliaresDesignados { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<SignoVital> SignosVitales { get; set; }
        public DbSet<SugerenciaCuidado> SugerenciasCuidado { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=hospiencasa.cbw6kgjrpznb.us-east-1.rds.amazonaws.com;Initial Catalog=HospiEnCasaData;User ID=admin;Password=hospiencasa1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SignoVital>()
                .HasOne<Paciente>(s => s.Paciente)
                .WithMany(p => p.SignoVitales)
                .HasForeignKey(s => s.IdPaciente);
            
            builder.HasAnnotation("Sqlite:Autoincement", true)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            
            base.OnModelCreating(builder);
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<FamiliarDesignado> FamiliaresDesignados { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<SignoVital> SignosVitales { get; set; }
        public DbSet<SugerenciaCuidado> SugerenciasCuidado { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }
        public DbSet<Usuario> Usuarios {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=hospiencasa.cbw6kgjrpznb.us-east-1.rds.amazonaws.com;Initial Catalog=HospiEnCasaData;User ID=admin;Password=hospiencasa1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<Paciente>().HasKey(propiedad => new { propiedad.Id });
            builder.Entity<FamiliarDesignado>().HasKey(propiedad => new { propiedad.Id });
            
            builder.HasAnnotation("Sqlite:Autoincement", true)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            
            base.OnModelCreating(builder);
        }
    }
}
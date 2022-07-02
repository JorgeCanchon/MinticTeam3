using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class AppContext:DbContext
  {
    //public DbSet<Persona> Personas {get;set;}
    public DbSet<Paciente> Pacientes {get;set;}
    public DbSet<Medico> Medicos {get;set;}
    public DbSet<FamiliarDesignado> FamiliaresDesignados {get;set;}
    public DbSet<Historia> Historias {get;set;}
    public DbSet<SignoVital> SignosVitales {get;set;}
    public DbSet<SugerenciaCuidado> SugerenciasCuidado {get;set;}
    public DbSet<Enfermera> Enfermeras {get;set;}
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-SHQ89UT;Initial Catalog=HospiEnCasaData;User ID=BizagiDatabaseAdmin;Password=johansSwq21321*;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
      }
    }
  }
}
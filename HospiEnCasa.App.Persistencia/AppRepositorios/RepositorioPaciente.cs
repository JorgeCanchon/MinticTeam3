using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioPaciente:IRepositorioPaciente
  {
    private readonly AppContext db;
    public RepositorioPaciente(AppContext db)
    {
      this.db = db;
    }

    public IEnumerable<Paciente> GetAllPacientes()
    {
      var paciente = db.Pacientes.ToList();

      // if(paciente.Count == 0)
      // {
      //   return NotFound();
      // }

      return paciente;
    }

    public Paciente GetPaciente(int id)
    {
      return db.Pacientes.Where(x => x.Id == id).FirstOrDefault();
    }

    public Paciente AddPaciente(Paciente paciente)
    {
      db.Pacientes.Add(paciente);
      
      db.SaveChanges();

      return paciente;
    }
  }
}
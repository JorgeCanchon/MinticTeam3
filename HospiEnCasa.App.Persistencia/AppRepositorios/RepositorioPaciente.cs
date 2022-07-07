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

    IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
    {
      return db.Pacientes;
    }

    Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
    {
      return db.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
    }

    Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
    {
      var pacienteNuevo = db.Pacientes.Add(paciente);

      db.SaveChanges();

      return pacienteNuevo.Entity;
    }

    Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
    {
      var pacienteEncontrado = db.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);

      if (pacienteEncontrado != null)
      {
        pacienteEncontrado.Nombre = paciente.Nombre;
        pacienteEncontrado.Apellidos = paciente.Apellidos;
        pacienteEncontrado.Telefono = paciente.Telefono;
        pacienteEncontrado.Genero = paciente.Genero;
        pacienteEncontrado.Direccion = paciente.Direccion;
        pacienteEncontrado.Latitud = paciente.Latitud;
        pacienteEncontrado.Longitud = paciente.Longitud;
        pacienteEncontrado.Ciudad = paciente.Ciudad;
        pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
        pacienteEncontrado.FamiliarDesignado = paciente.FamiliarDesignado;
        pacienteEncontrado.Enfermera = paciente.Enfermera;
        pacienteEncontrado.Medico = paciente.Medico;
        pacienteEncontrado.Historia = paciente.Historia;

        db.SaveChanges();
      }

      return pacienteEncontrado;
    }

    void IRepositorioPaciente.DeletePaciente(int idPaciente)
    {
      var pacienteEncontrado = db.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
      if (pacienteEncontrado == null)
      {
        return;
      } 
      db.Pacientes.Remove(pacienteEncontrado);
      db.SaveChanges();
    }
  }
}
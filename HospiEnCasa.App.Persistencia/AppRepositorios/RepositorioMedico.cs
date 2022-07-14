using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioMedico:IRepositorioMedico
  {
    private readonly AppContext db;
    public RepositorioMedico(AppContext db)
    {
      this.db = db;
    }

    IEnumerable<Medico> IRepositorioMedico.GetAllMedicos()
    {
      return db.Medicos;
    }

    Medico IRepositorioMedico.GetMedico(int idMedico)
    {
      return db.Medicos.FirstOrDefault(p => p.Id == idMedico);
    }

    Medico IRepositorioMedico.AddMedico(Medico medico)
    {
      var medicoNuevo = db.Medicos.Add(medico);

      db.SaveChanges();

      return medicoNuevo.Entity;
    }

    Medico IRepositorioMedico.UpdateMedico(Medico medico)
    {
      var medicoEncontrado = db.Medicos.FirstOrDefault(p => p.Id == medico.Id);

      if (medicoEncontrado != null)
      {
        medicoEncontrado.Nombre = medico.Nombre;
        medicoEncontrado.Apellidos = medico.Apellidos;
        medicoEncontrado.Telefono = medico.Telefono;
        medicoEncontrado.Genero = medico.Genero;
        medicoEncontrado.Especialidad = medico.Especialidad;
        medicoEncontrado.Codigo = medico.Codigo;
        medicoEncontrado.RegistroRethus = medico.RegistroRethus;

        db.SaveChanges();
      }

      return medicoEncontrado;
    }

    void IRepositorioMedico.DeleteMedico(int idMedico)
    {
      var medicoEncontrado = db.Medicos.FirstOrDefault(p => p.Id == idMedico);
      if (medicoEncontrado == null)
      {
        return;
      } 
      db.Medicos.Remove(medicoEncontrado);
      db.SaveChanges();
    }
  }
}
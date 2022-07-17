using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public class RepositorioMedico : RepositorioBase<Medico>, IRepositorioMedico
  {
    public RepositorioMedico(AppContext db) : base(db)
    {}
  }
}
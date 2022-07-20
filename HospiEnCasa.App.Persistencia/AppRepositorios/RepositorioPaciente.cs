using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente
    {
        public RepositorioPaciente(AppContext db) : base(db)
        { }
    }
}
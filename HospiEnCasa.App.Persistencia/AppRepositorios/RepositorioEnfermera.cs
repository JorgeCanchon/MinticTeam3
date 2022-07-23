using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : RepositorioBase<Enfermera>, IRepositorioEnfermera
    {
        public RepositorioEnfermera(AppContext db) : base(db)
        {}
    }
}
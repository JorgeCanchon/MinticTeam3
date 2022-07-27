using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioHistoria : RepositorioBase<Historia>, IRepositorioHistoria
    {
        public RepositorioHistoria(AppContext db) : base(db)
        {}
    }
}
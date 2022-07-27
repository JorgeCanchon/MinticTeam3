using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSignosVitales: RepositorioBase<SignoVital>, IRepositorioSignosVitales
    {
        public RepositorioSignosVitales(AppContext db)
            : base(db)
        {
        }
    }
}
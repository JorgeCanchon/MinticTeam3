using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioFamiliarDesignado : RepositorioBase<FamiliarDesignado>, IRepositorioFamiliarDesignado
    {
        public RepositorioFamiliarDesignado(AppContext db)
            : base(db)
        {
        }
    }
}
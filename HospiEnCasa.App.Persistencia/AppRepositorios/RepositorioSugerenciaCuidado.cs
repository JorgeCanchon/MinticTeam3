using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSugerenciaCuidado : RepositorioBase<SugerenciaCuidado>, IRepositorioSugerenciaCuidado
    {
        private readonly AppContext _db;
        public RepositorioSugerenciaCuidado(AppContext db)
            : base(db)
        {
            _db = db;
        }        
    }
}
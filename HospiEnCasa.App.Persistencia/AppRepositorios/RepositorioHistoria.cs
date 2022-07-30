using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioHistoria : RepositorioBase<Historia>, IRepositorioHistoria
    {
        private readonly AppContext _db;
        public RepositorioHistoria(AppContext db)
            : base(db)
        {
            _db = db;
        }
        public Historia ConsultarHistoriaConSugerenciaCuidado(int? idHistoria) =>
            _db.Historias.Where(x => x.IdHistoria == idHistoria).Include(x => x.Sugerencias).FirstOrDefault();
    }
}
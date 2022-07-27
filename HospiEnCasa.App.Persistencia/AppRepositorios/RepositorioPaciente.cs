using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente
    {
        private readonly AppContext _db;
        public RepositorioPaciente(AppContext db) 
            : base(db)
        {
            _db = db;
        }

        public Paciente ConsultarPacienteConSignosVitales(int? idPaciente)
        {
            return _db.Pacientes.Where(x => x.IdPaciente == idPaciente).Include(x => x.SignoVitales).FirstOrDefault();
        }
    }
}
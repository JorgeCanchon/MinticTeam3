using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages
{
    public class PacientesAsignadosModel : PageModel
    {
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IRepositorioPaciente _repositorioPaciente;
        public Dominio.Medico Medico {get;set;}
        public IQueryable<Dominio.Paciente> PacientesAsignados { get; set; }

        public PacientesAsignadosModel(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            _repositorioMedico = repositorioMedico;
            _repositorioPaciente = repositorioPaciente;
        }

        public void OnGet(int id)
        {
            PacientesAsignados = _repositorioPaciente.FindByCondition(p => p.Medico.Id == id);
        }
    }
}

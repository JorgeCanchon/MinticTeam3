using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Web.Pages
{
    public class PacientesRegistradosModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public IEnumerable<Paciente> Pacientes {get;set;}
        public PacientesRegistradosModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente;
        }
        public void OnGet()
        {
            Pacientes = _repositorioPaciente.GetAllPacientes();
        }
    }
}

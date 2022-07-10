using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Web.Pages
{
    public class PacientesRegistradosModel : PageModel
    {
        // private readonly IRepositorioPaciente repositorioPaciente;
        // public IEnumerable<Paciente> Pacientes {get;set;}
        /*public PacientesRegistradosModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }*/
        public void OnGet()
        {
            // Pacientes = repositorioPaciente.GetAllPacientes();
        }
    }
}

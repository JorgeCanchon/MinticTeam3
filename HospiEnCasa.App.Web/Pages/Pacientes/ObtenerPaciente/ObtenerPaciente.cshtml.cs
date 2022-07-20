using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages
{
    public class ObtenerPacienteModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public Paciente Paciente {get;set;}
        public ObtenerPacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente;
        }
        public void OnGet(int id)
        {
            Paciente = _repositorioPaciente.FindById(id);
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public List<Paciente> Pacientes {get;set;}

        public IndexModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente;
        }
        
        public void OnGet()
        {
            Pacientes = _repositorioPaciente.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

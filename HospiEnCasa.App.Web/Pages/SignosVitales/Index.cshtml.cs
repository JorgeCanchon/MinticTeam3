using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.SignosVitales
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Dominio.Paciente Paciente { get; set; }

        private readonly IRepositorioPaciente _repositorioPaciente;

        public IndexModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
        }
        
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Paciente = _repositorioPaciente.ConsultarPacienteConSignosVitales(id.Value);

                if (Paciente == null)
                {
                    return RedirectToPage("../Pacientes/Index");
                }
            }
            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.HistoriaClinica
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Dominio.Paciente> Paciente { get; set; }

        private readonly IRepositorioPaciente _repositorioPaciente;

        public IndexModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
        }
        
        public IActionResult OnGet()
        {
            Paciente = _repositorioPaciente.ConsultarPacientesConHistoriaClinica();
            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.Medicos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMedico _repositorioMedico;
        public List<Medico> Medicos {get;set;}
        public IndexModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico;
        }
        public void OnGet()
        {
            Medicos = _repositorioMedico.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

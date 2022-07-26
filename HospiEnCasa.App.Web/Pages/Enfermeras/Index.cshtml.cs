using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.Enfermeras
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEnfermera _repositorioEnfermera;
        public List<Dominio.Enfermera> Enfermeras { get; set; }

        public IndexModel(IRepositorioEnfermera repositorioEnfermera)
        {
            _repositorioEnfermera = repositorioEnfermera;
        }

        public void OnGet()
        {
            Enfermeras = _repositorioEnfermera.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

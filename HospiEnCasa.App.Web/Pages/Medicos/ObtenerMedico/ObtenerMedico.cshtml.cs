using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages
{
    public class ObtenerMedicoModel : PageModel
    {
        private readonly IRepositorioMedico _repositorioMedico;
        public Medico Medico {get;set;}
        public ObtenerMedicoModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico;
        }
        public void OnGet(int id)
        {
          Medico = _repositorioMedico.FindByCondition(id);
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

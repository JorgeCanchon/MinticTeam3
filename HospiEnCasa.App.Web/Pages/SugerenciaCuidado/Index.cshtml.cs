using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
using System.Collections;

namespace HospiEnCasa.App.Web.Pages.SugerenciaCuidado
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Dominio.Historia Historia { get; set; }

        private readonly IRepositorioHistoria _repositorioHistoria;

        public IndexModel(IRepositorioHistoria repositorioHistoria)
        {
            _repositorioHistoria = repositorioHistoria ?? throw new ArgumentNullException(nameof(repositorioHistoria));
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Historia = _repositorioHistoria.ConsultarHistoriaConSugerenciaCuidado(id.Value);

                if (Historia == null)
                {
                    return RedirectToPage("../HistoriaClinica/Index");
                }
            }
            return Page();
        }
    }
}

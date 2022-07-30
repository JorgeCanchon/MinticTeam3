using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
using System.Collections;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateHistoriaClinicaModel : PageModel
    {
        [BindProperty]
        public Dominio.Historia Historia { get; set; }
        public string ErrorMessage { get; set; }

        private readonly IRepositorioHistoria _repositorioHistoria;

        public AddUpdateHistoriaClinicaModel(IRepositorioHistoria repositorioHistoria)
        {
            _repositorioHistoria = repositorioHistoria ?? throw new ArgumentNullException(nameof(repositorioHistoria));
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["TitlePage"] = "Registrar Historia";
            if (id.HasValue)
            {
                 Historia = _repositorioHistoria.FindById(id.Value);

                if (Historia == null)
                {
                    return RedirectToPage("/HistoriaClinica/Index");
                }
                ViewData["TitlePage"] = "Actualizar Historia";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<string, bool, IActionResult> function = (string message, bool isCreate) =>
            {
                var historia = isCreate ? _repositorioHistoria.Create(Historia) : _repositorioHistoria.Update(Historia);
                if (historia.IdHistoria > 0)
                    return RedirectToPage("/HistoriaClinica/Index");

                ErrorMessage = "No se pudo actualizar la historia";

                return Page();
            };

            try
            {
                if (Historia.IdHistoria > 0)
                {
                    return function("No se pudo actualizar la historia", false);
                }

                return function("No se pudo insertar la historia", true);
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message + "\n" + exception.InnerException?.Message ?? string.Empty;
            }

            return Page();
        }

    }
}

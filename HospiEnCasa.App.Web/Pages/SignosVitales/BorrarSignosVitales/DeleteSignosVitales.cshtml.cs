using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;


namespace HospiEnCasa.App.Web.Pages
{
    public class DeleteSignosVitalesModel : PageModel
    {
        private readonly IRepositorioSignosVitales _repositorioSignosVitales;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Dominio.SignoVital SignoVital { get; set; }

        [BindProperty]
        public int? IdPaciente { get; set; }

        public DeleteSignosVitalesModel(IRepositorioSignosVitales repositorioSignosVitales)
        {
            _repositorioSignosVitales = repositorioSignosVitales ?? throw new ArgumentNullException(nameof(repositorioSignosVitales));
        }

        public IActionResult OnGet(int? id, int? idPaciente)
        {
            IdPaciente = idPaciente;
            if (id.HasValue)
            {
                SignoVital = _repositorioSignosVitales.FindById(id.Value);

                if (SignoVital == null)
                {
                    return RedirectToPage("/SignosVitales/Index", new { id = IdPaciente.ToString() });
                }
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                if (SignoVital != null)
                {
                    _repositorioSignosVitales.Delete(id);
                    return RedirectToPage("/SignosVitales/Index", new { id = IdPaciente.ToString() });
                }

                ErrorMessage = "No se pudo eliminar el signo";
                return Page();

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message;
            }

            return Page();
        }
    }
}

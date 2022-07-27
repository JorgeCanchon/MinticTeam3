using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
using System.Collections;


namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateSignosVitalesModel : PageModel
    {
        private readonly IRepositorioSignosVitales _repositorioSignosVitales;

        [BindProperty]
        public Dominio.SignoVital SignoVital { get; set; }
        [BindProperty]
        public int? IdPaciente { get; set; }
        public string ErrorMessage { get; set; }

        public AddUpdateSignosVitalesModel(IRepositorioSignosVitales repositorioSignosVitales)
        {
            _repositorioSignosVitales = repositorioSignosVitales ?? throw new ArgumentNullException(nameof(repositorioSignosVitales));
        }

        public IActionResult OnGet(int? id, int? idPaciente)
        {
            IdPaciente = idPaciente;
            ViewData["TitlePage"] = "Registrar Signo vital";
            if (id.HasValue)
            {
                SignoVital = _repositorioSignosVitales.FindById(id.Value);

                if (SignoVital == null)
                {
                    return RedirectToPage("/SignosVitales/Index", new { id = IdPaciente.ToString() });
                }
                ViewData["TitlePage"] = "Actualizar signo vital";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<string, bool, IActionResult> function = (string message, bool isCreate) =>
           {
               var signoVital = isCreate ? _repositorioSignosVitales.Create(SignoVital) : _repositorioSignosVitales.Update(SignoVital);
               if (signoVital.IdSignoVital > 0)
                   return RedirectToPage("/SignosVitales/Index", new { id = IdPaciente.ToString() });

               ErrorMessage = message;

               return Page();
           };

            try
            {
                SignoVital.IdPaciente = IdPaciente;
                if (SignoVital.IdSignoVital > 0)
                {
                    return function("No se pudo actualizar signo vital", false);
                }

                return function("No se pudo insertar signo vital", true);
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message + "\n" + exception.InnerException?.Message ?? string.Empty;
            }

            return Page();
        }
    }
}

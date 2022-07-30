using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
using System.Collections;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateSugerenciaCuidadoModel : PageModel
    {
        private readonly IRepositorioSugerenciaCuidado _repositorioSugerenciaCuidado;

        [BindProperty]
        public Dominio.SugerenciaCuidado SugerenciaCuidado { get; set; }
        [BindProperty]
        public int? IdHistoria { get; set; }
        public string ErrorMessage { get; set; }

        public AddUpdateSugerenciaCuidadoModel(IRepositorioSugerenciaCuidado repositorioSugerenciaCuidado)
        {
            _repositorioSugerenciaCuidado = repositorioSugerenciaCuidado ?? throw new ArgumentNullException(nameof(repositorioSugerenciaCuidado));
        }

        public IActionResult OnGet(int? id, int? idHistoria)
        {
            IdHistoria = idHistoria;
            ViewData["TitlePage"] = "Registrar Sugerencia Cuidado";
            if (id.HasValue)
            {
                SugerenciaCuidado = _repositorioSugerenciaCuidado.FindById(id.Value);

                if (SugerenciaCuidado == null)
                {
                    return RedirectToPage("/SugerenciaCuidado/Index", new { id = IdHistoria.ToString() });
                }
                ViewData["TitlePage"] = "Actualizar Sugerencia Cuidado";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<string, bool, IActionResult> function = (string message, bool isCreate) =>
           {
               var sugerenciaCuidado = isCreate ? _repositorioSugerenciaCuidado.Create(SugerenciaCuidado) : _repositorioSugerenciaCuidado.Update(SugerenciaCuidado);
               if (sugerenciaCuidado.IdSugerenciaCuidado > 0)
                   return RedirectToPage("/SugerenciaCuidado/Index", new { id = IdHistoria.ToString() });

               ErrorMessage = message;

               return Page();
           };

            try
            {
                SugerenciaCuidado.HistoriaIdHistoria = IdHistoria;
                if (SugerenciaCuidado.IdSugerenciaCuidado > 0)
                {
                    return function("No se pudo actualizar Sugerencia Cuidado", false);
                }

                return function("No se pudo insertar Sugerencia Cuidado", true);
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message + "\n" + exception.InnerException?.Message ?? string.Empty;
            }

            return Page();
        }
    }
}

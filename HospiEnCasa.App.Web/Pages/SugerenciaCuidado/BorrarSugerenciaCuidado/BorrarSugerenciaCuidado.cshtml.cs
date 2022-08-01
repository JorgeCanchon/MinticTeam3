using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
using System.Collections;

namespace HospiEnCasa.App.Web.Pages
{
    public class BorrarSugerenciaCuidadoModel : PageModel
    {
        private readonly IRepositorioSugerenciaCuidado _repositorioSugerenciaCuidado;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Dominio.SugerenciaCuidado SugerenciaCuidado { get; set; }

        [BindProperty]
        public int? IdHistoria { get; set; }

        public BorrarSugerenciaCuidadoModel(IRepositorioSugerenciaCuidado repositorioSugerenciaCuidado)
        {
            _repositorioSugerenciaCuidado = repositorioSugerenciaCuidado ?? throw new ArgumentNullException(nameof(repositorioSugerenciaCuidado));
        }

        public IActionResult OnGet(int? id, int? idHistoria)
        {
            IdHistoria = idHistoria;
            if (id.HasValue)
            {
                SugerenciaCuidado = _repositorioSugerenciaCuidado.FindById(id.Value);

                if (SugerenciaCuidado == null)
                {
                    return RedirectToPage("/Bo/Index", new { id = IdHistoria.ToString() });
                }
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                if (SugerenciaCuidado != null)
                {
                    _repositorioSugerenciaCuidado.Delete(id);
                    return RedirectToPage("/SugerenciaCuidado/Index", new { id = IdHistoria.ToString() });
                }

                ErrorMessage = "No se pudo eliminar la sugerencia de cuidado";
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

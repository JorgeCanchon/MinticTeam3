using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class DeleteEnfermeraModel : PageModel
    {
        private readonly IRepositorioEnfermera _repositorioEnfermera;
        public string ErrorMessage { get; set; }
        [BindProperty]
        public Dominio.Enfermera Enfermera { get; set; } 

        public DeleteEnfermeraModel(IRepositorioEnfermera repositorioEnfermera)
        {
            _repositorioEnfermera = repositorioEnfermera ?? throw new ArgumentNullException(nameof(repositorioEnfermera));
        }

        public IActionResult OnGet(int id)
        {
            Enfermera = _repositorioEnfermera.FindById(id);

            if(Enfermera == null)
            {
                return RedirectToPage("/Enfermeras/Index");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                if(Enfermera != null){
                    _repositorioEnfermera.Delete(id);
                    return RedirectToPage("/Enfermeras/Index");
                }

                ErrorMessage = "No se pudo eliminar la enfermera";
                return Page();

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }
        
           return Page();
        }
    }
}

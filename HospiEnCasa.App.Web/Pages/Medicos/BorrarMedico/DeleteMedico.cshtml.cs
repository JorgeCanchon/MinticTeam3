using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class DeleteMedicoModel : PageModel
    {
        private readonly IRepositorioMedico _repositorioMedico;
        public string ErrorMessage { get; set; }
        [BindProperty]
        public Dominio.Medico Medico { get; set; } 

        public DeleteMedicoModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
        }

        public IActionResult OnGet(int id)
        {
            Medico = _repositorioMedico.FindById(id);

            if(Medico == null)
            {
                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                if(Medico != null){
                    _repositorioMedico.Delete(id);
                    return RedirectToPage("/Medicos/Index");
                }

                ErrorMessage = "No se pudo eliminar el medico";
                return Page();

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }
        
           return Page();
        }
    }
}

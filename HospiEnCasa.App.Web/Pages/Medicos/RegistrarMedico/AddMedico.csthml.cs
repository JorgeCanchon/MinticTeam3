using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddMedicoModel : PageModel
    {
       private readonly IRepositorioMedico _repositorioMedico;
       [BindProperty]
        public Dominio.Medico Medico { get; set; }

        public string ErrorMessage { get; set; }

        public AddMedicoModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
        }

        public void OnGet()
        {
            
        }

        public ActionResult OnPost()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var medico = _repositorioMedico.Create(Medico);
                    if(medico.Id > 0);
                        return RedirectToPage("/Medicos/Index");
                    ErrorMessage = "No se pudo agregar medico";
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }
        
           return Page();
        }
    }
}
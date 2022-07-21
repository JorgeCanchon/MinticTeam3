using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class UpdateMedicoModel : PageModel
    {
       private readonly IRepositorioMedico _repositorioMedico;
       [BindProperty]
        public Dominio.Medico Medico { get; set; }

        public string ErrorMessage { get; set; }

        public UpdateMedicoModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
        }

        public ActionResult OnGet(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Medico = _repositorioMedico.FindById(id);

            if(Medico == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var medico = _repositorioMedico.Update(Medico);
                    if(medico.Id > 0);
                        return RedirectToPage("/Medicos/Index");
                    ErrorMessage = "No se pudo actualizar el medico";
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }
        
           return Page();
        }
    }
}
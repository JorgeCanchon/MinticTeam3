using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages.Pacientes
{
    public class DeletePacienteModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public string ErrorMessage { get; set; }
        public Paciente Paciente { get; set; } 

        public DeletePacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
        }

        public void OnGet(int id)
        {
            
            Paciente = _repositorioPaciente.FindById(id);
        }

        public ActionResult OnPost(int id)
        {
            try
            {
                if(id > 0)
                {
                    if(Paciente != null){
                        var entity = _repositorioPaciente.Delete(Paciente);
                        if(entity);
                            return RedirectToPage("/Pacientes/Index");
                    }

                    ErrorMessage = "No se pudo eliminar el paciente";
                    return Page();
                }

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }

           return Page();
        }
    }
}

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

        public IActionResult OnGet(int id)
        {
            Paciente = _repositorioPaciente.FindById(id);

            if(Paciente == null)
            {
                return RedirectToPage("/Pacientes/Index");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                if(Paciente != null){
                    _repositorioPaciente.Delete2(Paciente);
                    return RedirectToPage("/Pacientes/Index");
                }

                ErrorMessage = "No se pudo eliminar el paciente";
                return Page();

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }

           return Page();
        }
    }
}

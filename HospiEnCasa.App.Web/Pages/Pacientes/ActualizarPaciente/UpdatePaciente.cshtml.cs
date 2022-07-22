using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class UpdatePacienteModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public Dominio.Paciente Paciente {get;set;}
        public string ErrorMessage {get;set;}
        public UpdatePacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
        }
        public ActionResult OnGet(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Paciente = _repositorioPaciente.FindById(id);

            if(Paciente == null)
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
                    var paciente = _repositorioPaciente.Update(Paciente);
                    if(paciente.Id > 0)
                    {
                        return RedirectToPage("/Pacientes/Index");
                    }
                    ErrorMessage = "No se pudo actualizar el paciente";
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";
            } catch(Exception exception) {
                ErrorMessage = "Error " + exception.Message;
            }

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddPacienteModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IRepositorioMedico _repositorioMedico;
       [BindProperty]
        public Dominio.Paciente Paciente {get;set;}
       [BindProperty]
        public IEnumerable<Dominio.Medico> Medicos {get;set;}
        public string ErrorMessage {get;set;}
        public AddPacienteModel(IRepositorioPaciente repositorioPaciente, IRepositorioMedico repositorioMedico)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
        }
        public void OnGet()
        {
            Medicos = _repositorioMedico.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var paciente = _repositorioPaciente.Create(Paciente);
                    if(paciente.Id > 0)
                    {
                        return RedirectToPage("/Pacientes/Index");
                    }
                    ErrorMessage = "No se pudo agregar el paciente";
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";
            } catch(Exception exception) {
                ErrorMessage = "Error " + exception.Message;
            }

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;
using System.Collections;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdatePacienteModel : PageModel
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IRepositorioFamiliarDesignado _repositorioFamiliarDesignado;
        private readonly IRepositorioMedico _repositorioMedico;
        private readonly IRepositorioEnfermera _repositorioEnfermera;
        [BindProperty]
        public Dominio.Paciente Paciente { get; set; }
        [BindProperty]
        public List<Dominio.FamiliarDesignado> FamiliaresDesignados {get;set;}
        [BindProperty]
        public List<Dominio.Medico> Medicos {get;set;}
        [BindProperty]
        public List<Dominio.Enfermera> Enfermeras {get;set;}

        public string ErrorMessage { get; set; }

        public AddUpdatePacienteModel(IRepositorioPaciente repositorioPaciente, IRepositorioFamiliarDesignado repositorioFamiliarDesignado, IRepositorioMedico repositorioMedico, IRepositorioEnfermera repositorioEnfermera)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
            _repositorioEnfermera = repositorioEnfermera ?? throw new ArgumentNullException(nameof(repositorioEnfermera));
        }

        public IActionResult OnGet(int? id)
        {
            FamiliaresDesignados = _repositorioFamiliarDesignado.FindAll().ToList();
            Medicos = _repositorioMedico.FindAll().ToList();
            Enfermeras = _repositorioEnfermera.FindAll().ToList();

            ViewData["TitlePage"] = "Registrar Paciente";
            if (id.HasValue)
            {
                Paciente = _repositorioPaciente.FindById(id.Value);

                if (Paciente == null)
                {
                    return RedirectToPage("/Pacientes/Index");
                }
                ViewData["TitlePage"] = "Actualizar Paciente";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<IActionResult> function;

            if (Paciente.Id > 0)
            {
                function = () =>
                {
                    var paciente = _repositorioPaciente.Update(Paciente);
                    
                    if (paciente.Id > 0) 
                        return RedirectToPage("/Pacientes/Index");

                    ErrorMessage = "No se pudo actualizar el paciente";

                    return Page();
                };
            }
            else
            {
                function = () =>
                {
                    var paciente = _repositorioPaciente.Create(Paciente);
                    if (paciente.Id > 0) 
                        return RedirectToPage("/Pacientes/Index");

                    ErrorMessage = "No se pudo insertar paciente";
                    
                    return Page();
                };
            }

            try
            {
                Console.WriteLine(Paciente.Nombre);
                Console.WriteLine(Paciente.FechaNacimiento);
                Console.WriteLine(Paciente.Medico);
                Console.WriteLine(Paciente.FamiliarDesignado);
                Console.WriteLine(Paciente.Enfermera);
                if (ModelState.IsValid)
                {
                    return function();
                }
                ErrorMessage = "Modelo invalido por favor intente de nuevo";
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message;
            }

            return Page();
        }
    }
}
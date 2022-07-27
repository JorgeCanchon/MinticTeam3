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
        private readonly IRepositorioHistoria _repositorioHistoria;
        [BindProperty]
        public Dominio.Paciente Paciente { get; set; }
        [BindProperty]
        public Dominio.FamiliarDesignado FamiliarDesignado {get;set;}
        [BindProperty]
        public List<Dominio.Medico> Medicos { get; set; }
        [BindProperty]
        public Dominio.Medico Medico {get;set;}
        [BindProperty]
        public List<Dominio.Enfermera> Enfermeras {get;set;}
        [BindProperty]
        public Dominio.Enfermera Enfermera {get;set;}
        [BindProperty]
        public Dominio.Historia Historia { get; set; }
        [BindProperty]
        public Dominio.SignoVital SignoVital { get; set; }

        public string ErrorMessage { get; set; }

        public AddUpdatePacienteModel(IRepositorioPaciente repositorioPaciente, IRepositorioFamiliarDesignado repositorioFamiliarDesignado, IRepositorioMedico repositorioMedico, IRepositorioEnfermera repositorioEnfermera, IRepositorioHistoria repositorioHistoria)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
            _repositorioEnfermera = repositorioEnfermera ?? throw new ArgumentNullException(nameof(repositorioEnfermera));
            _repositorioHistoria = repositorioHistoria ?? throw new ArgumentNullException(nameof(repositorioHistoria));
        }

        public IActionResult OnGet(int? id)
        {
            Medicos = _repositorioMedico.FindAll().ToList();
            Enfermeras = _repositorioEnfermera.FindAll().ToList();

            ViewData["TitlePage"] = "Registrar Paciente";
            if (id.HasValue)
            {
                Paciente = _repositorioPaciente.FindById(id.Value);
                // Historia = _repositorioHistoria.FindById(Paciente.);

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

            if (Paciente.IdPaciente > 0)
            {
                function = () =>
                {
                    var paciente = _repositorioPaciente.Update(Paciente);
                    var familiarDesignado = _repositorioFamiliarDesignado.Update(FamiliarDesignado);
                    
                    if (paciente.IdPaciente > 0 && familiarDesignado.IdFamiliarDesignado > 0) 
                        return RedirectToPage("/Pacientes/Index");

                ErrorMessage = message;

                    return Page();
                };
            }
            else
            {
                function = () =>
                {
                    Paciente.IdPaciente = null;
                    Paciente.Medico = _repositorioMedico.FindById(Medico.IdMedico ?? 0);
                    Paciente.Enfermera = _repositorioEnfermera.FindById(Enfermera.IdEnfermera ?? 0);
                    Paciente.Historia = Historia;
                    Paciente.FamiliarDesignado = FamiliarDesignado;
                    Paciente.SignoVitales = new List<Dominio.SignoVital>()
                    {
                        SignoVital
                    };

                    var paciente = _repositorioPaciente.Create(Paciente);
                    if (paciente.IdPaciente > 0) 
                        return RedirectToPage("/Pacientes/Index");

                    ErrorMessage = "No se pudo insertar paciente";
                    
                    return Page();
                };
            }

            try
            {
                if (ModelState.IsValid)
                {
                    return function("No se pudo actualizar el paciente", false);
                }

                return function("No se pudo insertar el paciente", true);
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message + "\n" + exception.InnerException?.Message ?? string.Empty;
            }

            FillSelects();

            return Page();
        }

        private void FillSelects()
        {
            FamiliaresDesignados = _repositorioFamiliarDesignado.FindAll().ToList();
            Medicos = _repositorioMedico.FindAll().ToList();
            Enfermeras = _repositorioEnfermera.FindAll().ToList();
        }
    }
}
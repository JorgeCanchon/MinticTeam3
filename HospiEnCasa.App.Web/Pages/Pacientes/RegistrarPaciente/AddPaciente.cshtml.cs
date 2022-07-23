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
        private readonly IRepositorioEnfermera _repositorioEnfermera;

        [BindProperty]
        public Dominio.Paciente Paciente { get; set; }
        public IEnumerable<Dominio.Medico> Medicos { get; set; }
        [BindProperty]
        public Dominio.Medico Medico { get; set; }
        [BindProperty]
        public Dominio.SignoVital SignoVital { get; set; }
        [BindProperty]
        public Dominio.FamiliarDesignado FamiliarDesignado { get; set; }
        [BindProperty]
        public Dominio.Historia Historia { get; set; }
        public List<Dominio.Enfermera> Enfermeras { get; set; }
        [BindProperty]
        public Dominio.Enfermera Enfermera { get; set; }

        public string ErrorMessage { get; set; }

        public AddPacienteModel(IRepositorioPaciente repositorioPaciente, IRepositorioMedico repositorioMedico,
        IRepositorioEnfermera repositorioEnfermera)
        {
            _repositorioPaciente = repositorioPaciente ?? throw new ArgumentNullException(nameof(repositorioPaciente));
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
            _repositorioEnfermera = repositorioEnfermera ?? throw new ArgumentNullException(nameof(_repositorioEnfermera));
        }

        public void OnGet()
        {
            Medicos = _repositorioMedico.FindAll().ToList();
            Enfermeras = _repositorioEnfermera.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            try
            {
                Paciente.Id = null;
                Paciente.Medico = _repositorioMedico.FindById(Medico.Id ?? 0);
                Paciente.Enfermera = _repositorioEnfermera.FindById(Enfermera.Id ?? 0);
                Paciente.Historia = Historia;
                Paciente.FamiliarDesignado = FamiliarDesignado;
                Paciente.SignoVitales = new List<Dominio.SignoVital>() {
                    SignoVital
                };

                var paciente = _repositorioPaciente.Create(Paciente);
                if (paciente.Id > 0)
                {
                    return RedirectToPage("/Pacientes/Index");
                }

                ErrorMessage = "No se pudo agregar el paciente";
            }
            catch (Exception exception)
            {
                ErrorMessage = "Error " + exception.Message + "\n" + exception.InnerException?.Message ?? string.Empty;
            }

            Medicos = _repositorioMedico.FindAll().ToList();
            Enfermeras = _repositorioEnfermera.FindAll().ToList();
            return Page();
        }
    }
}

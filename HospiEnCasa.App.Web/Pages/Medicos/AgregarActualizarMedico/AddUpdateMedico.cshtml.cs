using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateMedicoModel : PageModel
    {
        private readonly IRepositorioMedico _repositorioMedico;

        [BindProperty]
        public Dominio.Medico Medico { get; set; }

        public string ErrorMessage { get; set; }

        public AddUpdateMedicoModel(IRepositorioMedico repositorioMedico)
        {
            _repositorioMedico = repositorioMedico ?? throw new ArgumentNullException(nameof(repositorioMedico));
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["TitlePage"] = "Registrar Medico";
            if (id.HasValue)
            {
                Medico = _repositorioMedico.FindById(id.Value);

                if (Medico == null)
                {
                    return RedirectToPage("/Medicos/Index");
                }
                ViewData["TitlePage"] = "Actualizar Medico";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<IActionResult> function;

            if (Medico.IdMedico > 0)
            {
                function = () =>
                {
                    var medico = _repositorioMedico.Update(Medico);
                    if (medico.IdMedico > 0) 
                        return RedirectToPage("/Medicos/Index");

                    ErrorMessage = "No se pudo actualizar el medico";

                    return Page();
                };
            }
            else
            {
                function = () =>
                {
                    var medico = _repositorioMedico.Create(Medico);
                    if (medico.IdMedico > 0) 
                        return RedirectToPage("/Medicos/Index");

                    ErrorMessage = "No se pudo insertar medico";
                    
                    return Page();
                };
            }

            try
            {
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
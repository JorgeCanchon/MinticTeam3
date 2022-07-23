using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateEnfermeraModel : PageModel
    {
        private readonly IRepositorioEnfermera _repositorioEnfermera;

        [BindProperty]
        public Dominio.Enfermera Enfermera { get; set; }

        public string ErrorMessage { get; set; }

        public AddUpdateEnfermeraModel(IRepositorioEnfermera repositorioEnfermera)
        {
            _repositorioEnfermera = repositorioEnfermera ?? throw new ArgumentNullException(nameof(repositorioEnfermera));
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["TitlePage"] = "Registrar Enfermera";
            if (id.HasValue)
            {
                Enfermera = _repositorioEnfermera.FindById(id.Value);

                if (Enfermera == null)
                {
                    return RedirectToPage("/Enfermeras/Index");
                }
                ViewData["TitlePage"] = "Actualizar Enfermera";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<IActionResult> function;

            if (Enfermera.Id > 0)
            {
                function = () =>
                {
                    var enfermera = _repositorioEnfermera.Update(Enfermera);
                    if (enfermera.Id > 0) 
                        return RedirectToPage("/Enfermeras/Index");

                    ErrorMessage = "No se pudo actualizar la enfermera";

                    return Page();
                };
            }
            else
            {
                function = () =>
                {
                    var enfermera = _repositorioEnfermera.Create(Enfermera);
                    if (enfermera.Id > 0) 
                        return RedirectToPage("/Enfermeras/Index");

                    ErrorMessage = "No se pudo insertar enfermera";
                    
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
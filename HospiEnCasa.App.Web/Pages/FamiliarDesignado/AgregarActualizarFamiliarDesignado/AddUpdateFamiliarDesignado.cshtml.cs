using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddUpdateFamiliarDesignadoModel : PageModel
    {
        private readonly IRepositorioFamiliarDesignado _repositorioFamiliarDesignado;

        [BindProperty]
        public Dominio.FamiliarDesignado FamiliarDesignado { get; set; }

        public string ErrorMessage { get; set; }

        public AddUpdateFamiliarDesignadoModel(IRepositorioFamiliarDesignado repositorioFamiliarDesignado)
        {
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["TitlePage"] = "Registrar Familiar Designado";
            if (id.HasValue)
            {
                FamiliarDesignado = _repositorioFamiliarDesignado.FindById(id.Value);

                if (FamiliarDesignado == null)
                {
                    return RedirectToPage("/FamiliarDesignado/Index");
                }
                ViewData["TitlePage"] = "Actualizar Familiar Designado";
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Func<IActionResult> function;

            if (FamiliarDesignado.IdFamiliarDesignado > 0)
            {
                function = () =>
                {
                    var familiar = _repositorioFamiliarDesignado.Update(FamiliarDesignado);
                    if (familiar.IdFamiliarDesignado > 0) 
                        return RedirectToPage("/FamiliarDesignado/Index");

                    ErrorMessage = "No se pudo actualizar el familiar";

                    return Page();
                };
            }
            else
            {
                function = () =>
                {
                    var familiar = _repositorioFamiliarDesignado.Create(FamiliarDesignado);
                    if (familiar.IdFamiliarDesignado > 0) 
                        return RedirectToPage("/FamiliarDesignado/Index");

                    ErrorMessage = "No se pudo insertar familiar";
                    
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
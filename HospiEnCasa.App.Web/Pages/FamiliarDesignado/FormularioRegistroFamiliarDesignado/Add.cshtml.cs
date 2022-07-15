using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class AddModel : PageModel
    {
        private readonly IRepositorioFamiliarDesignado _repositorioFamiliarDesignado;

        [BindProperty]
        public Dominio.FamiliarDesignado FamiliarDesignado { get; set; }

        public string ErrorMessage { get; set; }

        public AddModel(IRepositorioFamiliarDesignado repositorioFamiliarDesignado)
        {
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
        }

        public void OnGet()
        {
            
        }

        public ActionResult OnPost()
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var familiar = _repositorioFamiliarDesignado.Create(FamiliarDesignado);
                    if(familiar.Id > 0);
                        return RedirectToPage("/FamiliarDesignado/Index");
                    ErrorMessage = "No se pudo insertar familiar";
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }

        
           return Page();
        }
    }
}
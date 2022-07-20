using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System;

namespace HospiEnCasa.App.Web.Pages
{
    public class DeleteFamiliarDesignadoModel : PageModel
    {
        private readonly IRepositorioFamiliarDesignado _repositorioFamiliarDesignado;
        public string ErrorMessage { get; set; }
        public Dominio.FamiliarDesignado Familiar { get; set; } 

        public DeleteFamiliarDesignadoModel(IRepositorioFamiliarDesignado repositorioFamiliarDesignado)
        {
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
        }

        public void OnGet(int id)
        {
            
            Familiar = _repositorioFamiliarDesignado.FindById(id);
        }

        public ActionResult OnPost(int id)
        {
            try
            {
                if(id > 0)
                {
                    Familiar = _repositorioFamiliarDesignado.FindById(id);
                    if(Familiar != null){
                        var entity = _repositorioFamiliarDesignado.Delete(Familiar);
                        if(entity);
                            return RedirectToPage("/FamiliarDesignado/Index");
                    }

                    ErrorMessage = "No se pudo eliminar el familiar";
                    return Page();
                }

                ErrorMessage = "Id invalido por favor intente de nuevo";

            }catch(Exception exception){
                ErrorMessage = "Error " + exception.Message;
            }

        
           return Page();
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Web.Pages.Usuarios.Register
{
    public class RegisterModel : PageModel
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        [BindProperty]
        public Usuario Usuario {get;set;}

        public string ErrorMessage {get;set;}

        public RegisterModel(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Func<IActionResult> function = () =>
            {
                var usuario = _repositorioUsuario.Create(Usuario);
                if(usuario.IdUsuario > 0)
                    return RedirectToPage("/Login/Index");
                ErrorMessage = "No se pudo insertar usuario";

                return Page();
            };

            try
            {
                if(ModelState.IsValid)
                {
                    return function();
                }

                ErrorMessage = "Modelo invalido por favor intente de nuevo";
            }
            catch(Exception exception)
            {
                ErrorMessage = "Error " + exception.Message;
            }

            return Page();
        }
    }
}
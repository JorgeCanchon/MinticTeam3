using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Web.Pages.FamiliarDesignado
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioFamiliarDesignado _repositorioFamiliarDesignado;
        public List<Dominio.FamiliarDesignado> FamiliaresDesignados { get; set; }

        public IndexModel(IRepositorioFamiliarDesignado repositorioFamiliarDesignado)
        {
            _repositorioFamiliarDesignado = repositorioFamiliarDesignado ?? throw new ArgumentNullException(nameof(repositorioFamiliarDesignado));
        }

        public void OnGet()
        {
            FamiliaresDesignados = _repositorioFamiliarDesignado.FindAll().ToList();
        }

        public ActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Web.Pages
{
  public class LoginModel : PageModel
  {
    private readonly SignInManager<IdentityUser> _signInManager;

    [BindProperty]
    public Dominio.Login Model {get;set;}

    public LoginModel(SignInManager<IdentityUser> signInManager)
    {
      _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
      foreach (var modelState in ModelState.Values)
      {
        foreach (var modelError in modelState.Errors)
        {
          Console.WriteLine(modelError.ErrorMessage);
        }
      }

      if(ModelState.IsValid)
      {
        var identityResult = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
        if(identityResult.Succeeded)
        {
          if(returnUrl == null || returnUrl == "/")
          return RedirectToPage("Index");
        }
        else
        {
          return RedirectToPage(returnUrl);
        }
      }
      
      ModelState.AddModelError("", "Username or Password incorrect");
      
      return Page();
    }
  }
}
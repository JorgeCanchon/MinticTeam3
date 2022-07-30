using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;

namespace HospiEnCasa.App.Web.Pages
{
  public class RegisterModel : PageModel
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    [BindProperty]
    public Dominio.Register ModelRegister {get;set;}
    // public Rol Roles {get;set;}

    public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if(ModelState.IsValid)
      {
        var usuario = new IdentityUser()
        {
          UserName = ModelRegister.Email,
          Email = ModelRegister.Email
        };

        var result = await _userManager.CreateAsync(usuario, ModelRegister.Password);

        if(result.Succeeded)
        {
          if(!await _roleManager.RoleExistsAsync(Rol.AdminUser))
          {
            await _roleManager.CreateAsync(new IdentityRole(Rol.AdminUser));
          }

          if(!await _roleManager.RoleExistsAsync(Rol.MedicoUser))
          {
            await _roleManager.CreateAsync(new IdentityRole(Rol.MedicoUser));
          }

          if(!await _roleManager.RoleExistsAsync(Rol.CustomerUser))
          {
            await _roleManager.CreateAsync(new IdentityRole(Rol.CustomerUser));
          }

          await _userManager.AddToRoleAsync(usuario, Rol.CustomerUser);

          // var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
          // code = WebWebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

          await _signInManager.SignInAsync(usuario, false);

          return RedirectToPage("Index");
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      return Page();
    }
  }
}
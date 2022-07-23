using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Usuario
    {
      [Key]
      public int? Id { get; set; }
      [Required (ErrorMessage = "Required.")]
      [Display(Name = "User Name")]
      public string UserName {get;set;}
      [Required (ErrorMessage = "Required.")]
      // [DataType(DataType.Password)]
      public string Password {get;set;}
      [Required(ErrorMessage = "Required.")]
      [EmailAddress(ErrorMessage = "Invalid email address.")]
      public string Email{get;set;}
      public string Rol{get;set;}
      public System.DateTime CreatedDate { get; set; }
      public Nullable<System.DateTime> LastLoginDate { get; set; }
    }
}
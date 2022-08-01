using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Usuario
    {
        [Key]
        public int? IdUsuario {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        public string Rol {get;set;}
    }
}
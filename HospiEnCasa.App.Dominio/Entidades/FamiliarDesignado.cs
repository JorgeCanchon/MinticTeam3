using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class FamiliarDesignado
    {
        [Key]
        public int? IdFamiliarDesignado { get; set; }
        [Required]
        [Display(Prompt = "Ingrese nombre")]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public Genero Genero { get; set; }
        [Required]
        public string Parentesco { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
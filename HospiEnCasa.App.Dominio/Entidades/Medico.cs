using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Medico
    {
        [Key]
        public int? IdMedico { get; set; }
        [Required]
        [Display(Prompt = "Ingrese nombre")]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public Genero Genero { get; set; }
        public string Especialidad { get; set; }
        public string Codigo { get; set; }
        public string RegistroRethus { get; set; }
    }
}
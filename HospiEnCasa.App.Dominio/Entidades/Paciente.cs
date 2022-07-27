using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente
    {
        [Key]
        public int? IdPaciente { get; set; }
        [Required]
        [Display(Prompt = "Ingrese nombre")]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public Genero Genero { get; set; }
        [ForeignKey("IdHistoria")]
        public Historia Historia { get; set; }
        [ForeignKey("IdSignoVital")]
        public List<SignoVital> SignoVitales { get; set; }
        [ForeignKey("IdFamiliarDesignado")]
        public FamiliarDesignado FamiliarDesignado { get; set; }
        [ForeignKey("IdEnfermera")]
        public Enfermera Enfermera { get; set; }
        [ForeignKey("IdMedico")]
        public Medico Medico { get; set; }
        public string Direccion { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
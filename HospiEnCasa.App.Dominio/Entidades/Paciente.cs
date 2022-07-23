using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        [ForeignKey("Id")]
        public Historia Historia { get; set; }
        [ForeignKey("Id")]
        public List<SignoVital> SignoVitales { get; set; }
        [ForeignKey("Id")]
        public FamiliarDesignado FamiliarDesignado { get; set; }
        [ForeignKey("Id")]
        public Enfermera Enfermera { get; set; }
        [ForeignKey("Id")]
        public Medico Medico { get; set; }
        public string Direccion { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
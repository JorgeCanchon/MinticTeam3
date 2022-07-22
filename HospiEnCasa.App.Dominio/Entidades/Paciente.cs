using System;
using System.Collections.Generic;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        public Historia Historia { get; set; }
        /// Referencia a la lista de signos vitales del paciente
        public System.Collections.Generic.List<SignoVital> SignoVitales { get; set; }
        /// Relación entre paciente y su familiar designado
        public FamiliarDesignado FamiliarDesignado { get; set; }
        public Enfermera Enfermera { get; set; }
        public Medico Medico { get; set; }
        public string Direccion { get; set; }
        public float? Latitud { get; set; }
        public float? Longitud { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
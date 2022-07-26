using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Enfermera : Persona
    {
        public int? Id { get; set; }
        public string TarjetaProfesional { get; set; }
        public int HorasLaborales { get; set; }
    }
}
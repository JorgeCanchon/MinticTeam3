using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class FamiliarDesignado : Persona
    {
        public int? Id { get; set; }
        public string Parentesco { get; set; }
        public string Correo { get; set; }
    }
}
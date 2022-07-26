using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Medico : Persona
    {
        public int? Id { get; set; }
        public string Especialidad { get; set; }
        public string Codigo { get; set; }
        public string RegistroRethus { get; set; }
    }
}
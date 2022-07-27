using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class SugerenciaCuidado
    {
        [Key]
        public int IdSugerenciaCuidado { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
    }
}
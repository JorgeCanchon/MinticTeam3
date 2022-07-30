using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class SugerenciaCuidado
    {
        [Key]
        public int? IdSugerenciaCuidado { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public string Descripcion { get; set; }
          public int? HistoriaIdHistoria { get; set; }
    }
}
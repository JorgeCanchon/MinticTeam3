using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Historia
    {
        // [Required]
        public List<SugerenciaCuidado> Sugerencias { get; set; }
        [Key]
        public int IdHistoria { get; set; }
        [Required]
        public string Diagnostico { get; set; }
        [Required]
        public string Entorno { get; set; }
    }
}
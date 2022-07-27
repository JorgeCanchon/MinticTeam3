using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class Historia
    {
        public List<SugerenciaCuidado> Sugerencias { get; set; }
        [Key]
        public int IdHistoria { get; set; }
        public string Diagnostico { get; set; }
        public string Entorno { get; set; }
    }
}
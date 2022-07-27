using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class SignoVital
    {
        [Key]
        public int? IdSignoVital { get; set; }
        public DateTime FechaHora { get; set; }
        public float Valor { get; set; }
        public TipoSigno Signo { get; set; }

        public int? IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
    }
}
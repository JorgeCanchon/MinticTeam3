using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class SignoVital
    {
        [Key]
        public int? IdSignoVital { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public TipoSigno Signo { get; set; }

        public int? IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
    }
}
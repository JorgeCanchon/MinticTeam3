using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using System.Collections.Generic;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente : IRepositorioBase<Paciente>
    {
        Paciente ConsultarPacienteConSignosVitales(int? idPaciente);
        List<Paciente> ConsultarPacientesConHistoriaClinica();
    }
}
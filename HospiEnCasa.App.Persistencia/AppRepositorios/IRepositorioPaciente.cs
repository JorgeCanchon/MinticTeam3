using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente GetPaciente(int idPaciente);
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
    }
}
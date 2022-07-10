using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public interface IRepositorioMedico
  {
    IEnumerable<Medico> GetAllMedicos();
    Medico GetMedico(int idMedico);
    Medico AddMedico(Medico medico);
    Medico UpdateMedico(Medico medico);
    void DeleteMedico(int idMedico);
  }
}
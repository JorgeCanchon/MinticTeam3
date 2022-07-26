using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
  public interface IRepositorioUsuario
  {
    Usuario CreateUser(string email, string username, string password);
  }
}
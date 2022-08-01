using Formula1.Data.Entities;
using System.Threading.Tasks;

namespace Formula1.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task LogarUsuario(Usuario usuario);
        Task DeslogarUsuario();
    }
}
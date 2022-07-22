using Formula1.Data.Entities;
using System.Threading.Tasks;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IUsuariosRepository
    {
        bool ValidarPossuiUsuario();

        Usuario? ObterUsuarioLogin(string email, string senha);

        Task IncluirUsuario(Usuario usuario);
    }
}
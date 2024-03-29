using Formula1.Data.Entities;
using Formula1.Domain.Extensions;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1.Infra.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly F1Db Db;

        public UsuariosRepository(F1Db db)
        {
            Db = db;
        }

        public bool ValidarPossuiUsuario()
        {
            return Db.Usuarios.Any();
        }

        public Usuario? ObterUsuarioLogin(string email, string senha)
        {
            var usuario = Db.Usuarios.Where(o => o.Email == email).SingleOrDefault();

            if (usuario != null && usuario.Senha.CheckBCrypt(senha))
            {
                return usuario;
            }

            return null;
        }

        public async Task IncluirUsuario(Usuario usuario)
        {
            await Db.Usuarios.AddAsync(usuario);
            await Db.SaveChangesAsync();
        }
    }
}
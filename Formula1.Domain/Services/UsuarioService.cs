using Formula1.Data.Entities;
using Formula1.Domain.Extensions;
using Formula1.Infra.Database.SqlServer;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class UsuarioService
    {
        private readonly F1Db Db;

        public UsuarioService(F1Db db)
        {
            Db = db;
        }

        public Usuario CheckLogin(string email, string senha)
        {
            var usuario = Db.Usuarios.Where(o => o.Email == email).SingleOrDefault();

            if (usuario != null && usuario.Senha.CheckBCrypt(senha))
            {
                return usuario;
            }

            return null;
        }
    }
}
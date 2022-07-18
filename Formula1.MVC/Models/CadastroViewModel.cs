using Formula1.Data.Entities;
using Formula1.Domain.Extensions;

namespace Formula1.MVC.Models
{
    public class CadastroViewModel
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? ConfirmacaoEmail { get; set; }

        public string? Senha { get; set; }

        public string? ConfirmacaoSenha { get; set; }

        public Usuario MapUsuario()
        {
            return new Usuario()
            {
                Nome = this.Nome ?? string.Empty,
                Email = this.Email ?? string.Empty,
                Senha = this.Senha?.GetBCrypt(12) ?? string.Empty
            };
        }
    }
}
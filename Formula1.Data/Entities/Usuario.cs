namespace Formula1.Data.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public Usuario() : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
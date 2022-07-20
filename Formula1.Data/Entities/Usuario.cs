namespace Formula1.Data.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public Usuario()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
        }
    }
}
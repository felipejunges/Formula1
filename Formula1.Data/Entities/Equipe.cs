using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Equipe : Entity
    {
        public Equipe()
        {
            Contratos = new HashSet<Contrato>();
            Resultados = new HashSet<Resultado>();
        }

        public Equipe(int id, string nome, string corRgb)
            : this()
        {
            Id = id;
            Nome = nome;
            CorRgb = corRgb;
        }

        public string Nome { get; set; }

        public string CorRgb { get; set; }

        // TODO: criar estrutura Equipe x Campeonato pra armazenar o motor

        public virtual ICollection<Contrato> Contratos { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
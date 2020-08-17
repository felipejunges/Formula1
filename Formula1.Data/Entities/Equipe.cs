using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Equipe : Entity
    {
        public Equipe()
        {
            Contratos = new HashSet<Contrato>();
            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
            Temporadas = new HashSet<EquipeTemporada>();
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

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Punicao> Punicoes { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
        public virtual ICollection<EquipeTemporada> Temporadas { get; set; }
    }
}
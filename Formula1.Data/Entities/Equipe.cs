using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Equipe : Entity
    {
        public string Nome { get; private set; }

        public string CorRgb { get; private set; }

        public bool Ativo { get; private set; }

        public virtual ICollection<Contrato> Contratos { get; private set; }
        public virtual ICollection<Punicao> Punicoes { get; private set; }
        public virtual ICollection<Resultado> Resultados { get; private set; }
        public virtual ICollection<EquipeTemporada> Temporadas { get; private set; }

        public Equipe() : this(0, string.Empty, string.Empty, true)
        {
        }

        public Equipe(int id, string nome, string corRgb, bool ativo)
        {
            Id = id;
            Nome = nome;
            CorRgb = corRgb;
            Ativo = ativo;

            Contratos = new HashSet<Contrato>();
            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
            Temporadas = new HashSet<EquipeTemporada>();
        }

        public void Atualizar(string nome, string corRgb, bool ativo)
        {
            Nome = nome;
            CorRgb = corRgb;
            Ativo = ativo;
        }
    }
}
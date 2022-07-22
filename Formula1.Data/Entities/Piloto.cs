using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Piloto : Entity
    {
        public string Nome { get; private set; }

        public string NomeGuerra { get; private set; }

        public string Sigla { get; private set; }

        public int NumeroCarro { get; private set; }

        public string PaisOrigem { get; private set; }

        public bool Ativo { get; private set; }

        public virtual ICollection<Contrato> Contratos { get;private  set; }
        public virtual ICollection<Punicao> Punicoes { get; private set; }
        public virtual ICollection<Resultado> Resultados { get; private set; }
        public virtual ICollection<PilotoTemporada> Temporadas { get; private set; }

        public Piloto() : this(0, string.Empty, string.Empty, string.Empty, 0, string.Empty, true)
        {
        }

        public Piloto(int id, string nome, string nomeGuerra, string sigla, int numeroCarro, string paisOrigem, bool ativo)
        {
            Id = id;
            Nome = nome;
            NomeGuerra = nomeGuerra;
            Sigla = sigla;
            NumeroCarro = numeroCarro;
            PaisOrigem = paisOrigem;
            Ativo = ativo;

            Contratos = new HashSet<Contrato>();
            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
            Temporadas = new HashSet<PilotoTemporada>();
        }

        public void Atualizar(string nome, string nomeGuerra, string sigla, int numeroCarro, string paisOrigem, bool ativo)
        {
            Nome = nome;
            NomeGuerra = nomeGuerra;
            Sigla = sigla;
            NumeroCarro = numeroCarro;
            PaisOrigem = paisOrigem;
            Ativo = ativo;
        }
    }
}
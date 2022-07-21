using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Entities
{
    public class Corrida : Entity
    {
        public int Temporada { get; set; }

        public int NumeroCorrida { get; set; }

        public string NomeGrandePremio { get; set; }

        public string Circuito { get; set; }

        public DateTime DataHoraBrasil { get; set; }

        public bool CorridaClassificacao { get; set; }

        public bool MetadePontos { get; set; }

        public virtual ICollection<Punicao> Punicoes { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }

        public bool TemResultadoDeCorrida => Resultados.Any(c => c.PosicaoChegada > 0);

        public Corrida()
        {
            NomeGrandePremio = string.Empty;
            Circuito = string.Empty;

            Punicoes = new HashSet<Punicao>();
            Resultados = new HashSet<Resultado>();
        }
    }
}
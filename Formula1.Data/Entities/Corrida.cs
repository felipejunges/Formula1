using System;
using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Corrida : Entity
    {
        public Corrida()
        {
            this.Resultados = new HashSet<Resultado>();
        }

        public Corrida(int id, int temporada, string nomeGrandePremio, string circuito, DateTime dataHoraBrasil)
            : this()
        {
            Id = id;
            Temporada = temporada;
            NomeGrandePremio = nomeGrandePremio;
            Circuito = circuito;
            DataHoraBrasil = dataHoraBrasil;
        }

        public int Temporada { get; set; }

        public string NomeGrandePremio { get; set; }

        public string Circuito { get; set; }

        public DateTime DataHoraBrasil { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
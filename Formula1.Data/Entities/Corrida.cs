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

        public Corrida(int id, int temporada, string nomeGrandePremio, string pais, DateTime dataHoraBrasil) : this()
        {
            Id = id;
            Temporada = temporada;
            NomeGrandePremio = nomeGrandePremio;
            Pais = pais;
            DataHoraBrasil = dataHoraBrasil;
        }

        public int Temporada { get; set; }

        public string NomeGrandePremio { get; set; }

        public string Pais { get; set; }

        public DateTime DataHoraBrasil { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
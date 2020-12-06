using System;
using System.Collections.Generic;

namespace Formula1.Data.Entities
{
    public class Corrida : Entity
    {
        public Corrida()
        {
            this.Punicoes = new HashSet<Punicao>();
            this.Resultados = new HashSet<Resultado>();
        }

        public int Temporada { get; set; }

        public string NomeGrandePremio { get; set; }

        public string Circuito { get; set; }

        public DateTime DataHoraBrasil { get; set; }

        public virtual ICollection<Punicao> Punicoes { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
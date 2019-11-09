using System;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class CorridaTemporada
    {
        public int Id { get; set; }
        public DateTime DataHoraBrasil { get; set; }
        public string NomeGrandePremio { get; set; }

        public List<ResultadoTemporada> Resultados { get; set; }

        public bool TemResultados => Resultados.Count > 0;

        public CorridaTemporada()
        {
            Resultados = new List<ResultadoTemporada>();
        }
    }
}
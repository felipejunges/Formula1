using System;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class CorridaTemporada
    {
        public int Id { get; set; }
        public DateTime DataHoraBrasil { get; set; }
        public string NomeGrandePremio { get; set; }
        public bool TemResultadosDeCorrida { get; set; }

        public List<ResultadoTemporada> Resultados { get; set; }

        public CorridaTemporada()
        {
            Resultados = new List<ResultadoTemporada>();
        }
    }
}
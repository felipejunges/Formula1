using System;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class CorridaTemporada
    {
        public int Id { get; set; }
        public bool CorridaSprint { get; set; }
        public DateTime DataHoraBrasil { get; set; }
        public string NomeGrandePremio { get; set; }
        public bool TemResultadosDeCorrida { get; set; }

        public CorridaTemporada(int id, bool corridaSprint, DateTime dataHoraBrasil, string nomeGrandePremio, bool temResultadosDeCorrida)
        {
            Id = id;
            CorridaSprint = corridaSprint;
            DataHoraBrasil = dataHoraBrasil;
            NomeGrandePremio = nomeGrandePremio;
            TemResultadosDeCorrida = temResultadosDeCorrida;
        }
    }
}
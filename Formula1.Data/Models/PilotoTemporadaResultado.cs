using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class PilotoTemporadaResultado
    {
        public int Id { get; set; }

        public string NomeGuerra { get; set; }

        public string CorRgb { get; set; }

        public decimal Pontos { get; set; }

        public int Posicao { get; set; }

        public List<ResultadoTemporada> Resultados { get; set; }

        public int PosicaoMaxima { get; set; }

        public PilotoTemporadaResultado()
        {
            Resultados = new List<ResultadoTemporada>();
        }
    }
}
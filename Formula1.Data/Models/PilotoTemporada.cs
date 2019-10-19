using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class PilotoTemporada
    {
        public int Id { get; set; }

        public string NomeGuerra { get; set; }

        public string CorRgb { get; set; }

        public int PontosTemporada
        {
            get
            {
                return Resultados != null ? Resultados.Sum(s => s.Pontos) : 0;
            }
        }

        public List<ResultadoTemporada> Resultados { get; set; }

        public bool DisputaCampeonato { get; set; }
    }
}
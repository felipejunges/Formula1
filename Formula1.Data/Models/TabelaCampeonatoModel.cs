using Formula1.Data.Entities;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoModel
    {
        public List<Corrida> Corridas { get; set; }

        public List<PilotoResultadosModel> PilotoResultados { get; set; }

        public TabelaCampeonatoModel(List<Corrida> corridas, List<PilotoResultadosModel> pilotoResultados)
        {
            Corridas = corridas;
            PilotoResultados = pilotoResultados;
        }
    }
}
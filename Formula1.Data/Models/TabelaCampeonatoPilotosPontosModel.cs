using Formula1.Data.Entities;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoPilotosPontosModel
    {
        public List<Corrida> Corridas { get; set; }

        public List<PilotoResultadosPontosModel> PilotosResultados { get; set; }

        public TabelaCampeonatoPilotosPontosModel(List<Corrida> corridas, List<PilotoResultadosPontosModel> pilotoResultados)
        {
            Corridas = corridas;
            PilotosResultados = pilotoResultados;
        }
    }
}
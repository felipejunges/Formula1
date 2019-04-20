using Formula1.Data.Entities;
using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoPilotosPosicoesModel
    {
        public List<Corrida> Corridas { get; set; }

        public List<PilotoResultadosPosicaoModel> PilotosResultados { get; set; }

        public TabelaCampeonatoPilotosPosicoesModel(List<Corrida> corridas, List<PilotoResultadosPosicaoModel> pilotoResultados)
        {
            Corridas = corridas;
            PilotosResultados = pilotoResultados;
        }
    }
}
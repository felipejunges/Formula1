using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoPilotosModel
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<PilotoTemporada> Pilotos { get; private set; }

        public TabelaCampeonatoPilotosModel(List<CorridaTemporada> corridas, List<PilotoTemporada> pilotos)
        {
            Corridas = corridas;
            Pilotos = pilotos;
        }
    }
}
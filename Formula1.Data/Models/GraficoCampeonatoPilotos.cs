using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class GraficoCampeonatoPilotos
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<PilotoPontosGrafico> Pilotos { get; private set; }

        public GraficoCampeonatoPilotos(List<CorridaTemporada> corridas, List<PilotoPontosGrafico> pilotos)
        {
            Corridas = corridas;
            Pilotos = pilotos;
        }
    }
}
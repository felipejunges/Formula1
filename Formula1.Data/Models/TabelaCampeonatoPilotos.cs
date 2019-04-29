using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoPilotos
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<PilotoTemporada> Pilotos { get; private set; }

        public TabelaCampeonatoPilotos(List<CorridaTemporada> corridas, List<PilotoTemporada> pilotos)
        {
            Corridas = corridas;
            Pilotos = pilotos;
        }
    }
}
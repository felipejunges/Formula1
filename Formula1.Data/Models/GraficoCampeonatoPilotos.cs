using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class GraficoCampeonatoPilotos
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<PilotoPontosGrafico> Pilotos { get; private set; }

        public int Step { get => 10; }

        public decimal MaxValue
        {
            get
            {
                decimal maxPontos = Pilotos.Max(p => p.Pontos.Max() ?? 0);

                if (maxPontos == 0)
                    return maxPontos;

                var divisor = (int)Math.Ceiling((decimal)maxPontos / Step);

                return divisor * Step;
            }
        }

        public GraficoCampeonatoPilotos(List<CorridaTemporada> corridas, List<PilotoPontosGrafico> pilotos)
        {
            Corridas = corridas;
            Pilotos = pilotos;
        }
    }
}
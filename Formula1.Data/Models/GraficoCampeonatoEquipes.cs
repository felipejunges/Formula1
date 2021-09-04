using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class GraficoCampeonatoEquipes
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<EquipePontosGrafico> Equipes { get; private set; }

        public int Step { get => 10; }

        public double MaxValue
        {
            get
            {
                double maxPontos = Equipes.Max(p => p.Pontos.Max() ?? 0);

                if (maxPontos == 0)
                    return maxPontos;

                var divisor = (int)Math.Ceiling((double)maxPontos / Step);

                return divisor * Step;
            }
        }

        public GraficoCampeonatoEquipes(List<CorridaTemporada> corridas, List<EquipePontosGrafico> equipes)
        {
            Corridas = corridas;
            Equipes = equipes;
        }
    }
}
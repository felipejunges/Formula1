using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class GraficoCampeonatoEquipes
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<EquipePontosGrafico> Equipes { get; private set; }

        public bool HighHeight { get; private set; }

        public int Step { get => 20; }

        public int Height => (int)Math.Ceiling(MaxValue * (HighHeight ? 10D : 1.5D));

        public double MaxValue
        {
            get
            {
                double maxPontos = Equipes.Any() ? Equipes.Max(p => p.Pontos.Max() ?? 0) : 0;

                if (maxPontos == 0)
                    return maxPontos;

                var divisor = (int)Math.Ceiling((double)maxPontos / Step);

                return divisor * Step;
            }
        }

        public GraficoCampeonatoEquipes(List<CorridaTemporada> corridas, List<EquipePontosGrafico> equipes, bool highHeight)
        {
            Corridas = corridas;
            Equipes = equipes;
            HighHeight = highHeight;
        }
    }
}
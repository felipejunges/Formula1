using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class GraficoCampeonatoEquipes
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<EquipePontosGrafico> Equipes { get; private set; }

        public GraficoCampeonatoEquipes(List<CorridaTemporada> corridas, List<EquipePontosGrafico> equipes)
        {
            Corridas = corridas;
            Equipes = equipes;
        }
    }
}
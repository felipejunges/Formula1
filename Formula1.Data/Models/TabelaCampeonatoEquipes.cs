using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoEquipes
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<EquipeTemporadaResultado> Equipes { get; private set; }

        public TabelaCampeonatoEquipes(List<CorridaTemporada> corridas, List<EquipeTemporadaResultado> equipes)
        {
            Corridas = corridas;
            Equipes = equipes;
        }
    }
}
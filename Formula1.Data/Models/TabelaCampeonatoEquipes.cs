using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoEquipes
    {
        public List<CorridaTemporada> Corridas { get; private set; }

        public List<EquipeTemporada> Equipes { get; private set; }

        public TabelaCampeonatoEquipes(List<CorridaTemporada> corridas, List<EquipeTemporada> equipes)
        {
            Corridas = corridas;
            Equipes = equipes;
        }
    }
}
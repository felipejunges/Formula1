using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoEquipesModel
    {
        public List<CorridaTemporada> Corridas { get; set; }

        public List<EquipeTemporada> Equipes { get; set; }

        public TabelaCampeonatoEquipesModel(List<CorridaTemporada> corridas, List<EquipeTemporada> equipes)
        {
            Corridas = corridas;
            Equipes = equipes;
        }
    }
}
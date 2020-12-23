using System.Collections.Generic;

namespace Formula1.Data.Models.Admin.Equipes
{
    public class EquipeListaDados
    {
        public EquipeDados Dados { get; set; }
        public List<EquipeLista> Equipes { get; set; }

        public EquipeListaDados(EquipeDados dados, List<EquipeLista> equipes)
        {
            Dados = dados;
            Equipes = equipes;
        }
    }
}
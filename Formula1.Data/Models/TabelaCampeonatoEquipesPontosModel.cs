using Formula1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Data.Models
{
    public class TabelaCampeonatoEquipesPontosModel
    {
        public List<Corrida> Corridas { get; set; }

        public List<EquipeResultadosPontosModel> EquipesResultados { get; set; }

        public TabelaCampeonatoEquipesPontosModel(List<Corrida> corridas, List<EquipeResultadosPontosModel> equipesResultados)
        {
            Corridas = corridas;
            EquipesResultados = equipesResultados;
        }
    }
}
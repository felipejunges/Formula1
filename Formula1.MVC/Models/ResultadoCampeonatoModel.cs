using Formula1.Data.Entities;
using System.Collections.Generic;

namespace Formula1.MVC.Models
{
    public class ResultadoCampeonatoModel
    {
        public List<Corrida> Corridas { get; set; }

        public List<Piloto> Pilotos { get; set; }

        public ResultadoCampeonatoModel(List<Corrida> corridas, List<Piloto> pilotos)
        {
            Corridas = corridas;
            Pilotos = pilotos;
        }
    }
}
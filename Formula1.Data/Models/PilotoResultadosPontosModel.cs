using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Data.Models
{
    public class PilotoResultadosPontosModel
    {
        public string Piloto { get; set; }

        public int TotalPontos { get; set; }

        public Dictionary<int, int> Resultados { get; set; }

        public PilotoResultadosPontosModel(string piloto, int corridaId, int pontos)
        {
            Piloto = piloto;
            TotalPontos = pontos;

            Resultados = new Dictionary<int, int>
            {
                { corridaId, pontos }
            };
        }

        public void AddResultado(int corridaId, int pontos)
        {
            TotalPontos += pontos;
            Resultados.Add(corridaId, pontos);
        }
    }
}

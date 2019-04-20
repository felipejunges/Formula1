using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Data.Models
{
    public class EquipeResultadosPontosModel
    {
        public string Equipe { get; set; }

        public int TotalPontos { get; set; }

        public Dictionary<int, int> Resultados { get; set; }

        public EquipeResultadosPontosModel(string equipe, int corridaId, int pontos)
        {
            Equipe = equipe;
            TotalPontos = pontos;

            Resultados = new Dictionary<int, int>
            {
                { corridaId, pontos }
            };
        }

        public void AddResultado(int corridaId, int pontos)
        {
            TotalPontos += pontos;

            if (Resultados.ContainsKey(corridaId))
                Resultados[corridaId] += pontos;
            else
                Resultados.Add(corridaId, pontos);
        }
    }
}
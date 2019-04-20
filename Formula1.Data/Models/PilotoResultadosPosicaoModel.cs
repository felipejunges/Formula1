using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class PilotoResultadosPosicaoModel
    {
        public string Piloto { get; set; }

        public int TotalPontos { get; set; }

        public Dictionary<int, int> Resultados { get; set; }

        public PilotoResultadosPosicaoModel(string piloto, int corridaId, int posicaoChegada, int pontos)
        {
            Piloto = piloto;
            TotalPontos = pontos;

            Resultados = new Dictionary<int, int>
            {
                { corridaId, posicaoChegada }
            };
        }

        public void AddResultado(int corridaId, int posicaoChegada, int pontos)
        {
            TotalPontos += pontos;
            Resultados.Add(corridaId, posicaoChegada);
        }
    }
}
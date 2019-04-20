using System.Collections.Generic;

namespace Formula1.Data.Models
{
    public class PilotoResultadosModel
    {
        public string Piloto { get; set; }

        public int Pontos { get; set; }

        public Dictionary<int, int> Resultados { get; set; }

        public PilotoResultadosModel(string piloto, int corridaId, int posicaoChegada, int pontos)
        {
            Piloto = piloto;
            Pontos = pontos;

            Resultados = new Dictionary<int, int>
            {
                { corridaId, posicaoChegada }
            };
        }

        public void AddResultado(int corridaId, int posicaoChegada, int pontos)
        {
            Pontos += pontos;
            Resultados.Add(corridaId, posicaoChegada);
        }
    }
}
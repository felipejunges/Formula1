using System.Collections.Generic;
using System.Linq;

namespace Formula1.Data.Models
{
    public class PilotoTemporada
    {
        public int Id { get; set; }

        public string NomeGuerra { get; set; }

        public string CorRgb { get; set; }

        public int PontosTemporada
        {
            get
            {
                return Resultados != null ? Resultados.Sum(s => s.Pontos) : 0;
            }
        }

        public List<ResultadoTemporada> Resultados { get; set; }

        public int PosicaoMaxima { get; set; }

        public long GerarCriterioDesempate(int pilotosPorProva, int quantidadeCorridas)
        {
            long total = 0;

            var quantidadesResultados = Resultados.GroupBy(o => o.PosicaoChegada).Select(o => new { Posicao = o.Key, Quantidade = o.Count() });

            foreach(var quantidadeResultado in quantidadesResultados)
            {
                int posicaoInvertida = pilotosPorProva - quantidadeResultado.Posicao;

                long soma = posicaoInvertida * quantidadeCorridas;

                return quantidadeResultado.Quantidade + soma;
            }

            return total;
        }

        public PilotoTemporada()
        {
            Resultados = new List<ResultadoTemporada>();
        }
    }
}
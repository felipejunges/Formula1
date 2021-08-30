using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoLista
    {
        public int Id { get; set; }

        public string Piloto { get; set; }

        public string Equipe { get; set; }

        public bool TeveCorridaClassificacao { get; set; }

        public bool CorridaMetadePontos { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        public decimal Pontos { get; set; }

        [Display(Name = "Ponto extra")]
        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public bool Grifar { get; set; }

        public decimal PontosCalculados
        {
            get
            {
                decimal pontosPosicao =
                    PosicaoChegada == 1 ? 25M
                    : PosicaoChegada == 2 ? 18M
                    : PosicaoChegada == 3 ? 15M
                    : PosicaoChegada == 4 ? 12M
                    : PosicaoChegada == 5 ? 10M
                    : PosicaoChegada == 6 ? 8M
                    : PosicaoChegada == 7 ? 6M
                    : PosicaoChegada == 8 ? 4M
                    : PosicaoChegada == 9 ? 2M
                    : PosicaoChegada == 10 ? 1M
                    : 0M;

                if (CorridaMetadePontos) pontosPosicao /= 2;

                int pontoExtra = PontoExtra && PosicaoChegada <= 10 ? 1 : 0;

                int pontosClassificacao =
                    !TeveCorridaClassificacao ? 0
                    : PosicaoLargada == 1 ? 3
                    : PosicaoLargada == 2 ? 2
                    : PosicaoLargada == 3 ? 1
                    : 0;

                return pontosPosicao + pontoExtra + pontosClassificacao;
            }
        }

        private ResultadoLista()
        {
        }

        public ResultadoLista(int id, string piloto, string equipe, bool teveCorridaClassificacao, bool corridaMetadePontos, int posicaoLargada, int posicaoChegada, decimal pontos, bool pontoExtra, bool dnf, bool dsq, bool grifar)
        {
            Id = id;
            Piloto = piloto;
            Equipe = equipe;
            TeveCorridaClassificacao = teveCorridaClassificacao;
            CorridaMetadePontos = corridaMetadePontos;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            Pontos = pontos;
            PontoExtra = pontoExtra;
            DNF = dnf;
            DSQ = dsq;
            Grifar = grifar;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoLista
    {
        public int Id { get; set; }

        public string Piloto { get; set; }

        public string Equipe { get; set; }

        public bool TeveCorridaClassificacao { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        [Display(Name = "Ponto extra")]
        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public bool Grifar { get; set; }

        public int PontosCalculados
        {
            get
            {
                int pontosPosicao =
                    PosicaoChegada == 1 ? 25
                    : PosicaoChegada == 2 ? 18
                    : PosicaoChegada == 3 ? 15
                    : PosicaoChegada == 4 ? 12
                    : PosicaoChegada == 5 ? 10
                    : PosicaoChegada == 6 ? 8
                    : PosicaoChegada == 7 ? 6
                    : PosicaoChegada == 8 ? 4
                    : PosicaoChegada == 9 ? 2
                    : PosicaoChegada == 10 ? 1
                    : 0;

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

        public ResultadoLista(int id, string piloto, string equipe, bool teveCorridaClassificacao, int posicaoLargada, int posicaoChegada, int pontos, bool pontoExtra, bool dnf, bool dsq, bool grifar)
        {
            Id = id;
            Piloto = piloto;
            Equipe = equipe;
            TeveCorridaClassificacao = teveCorridaClassificacao;
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
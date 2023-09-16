using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoLista
    {
        public int Id { get; set; }

        public string Piloto { get; set; }

        public string Equipe { get; set; }

        public bool CorridaMetadePontos { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        [Display(Name = "Pts. class.")]
        public double PontosClassificacao { get; set; }

        [Display(Name = "Pts. corrida")]
        public double PontosCorrida { get; set; }

        [Display(Name = "Volta mais rápida")]
        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public bool GrifarPontosCorrida { get; set; }

        public bool GrifarPontosClassificacao { get; set; }

        public bool GrifarChegada { get; set; }

        public bool GrifarLargada { get; set; }

        public bool GrifarEquipe { get; set; }

        public double PontosCorridaCalculados
        {
            get
            {
                double pontosPosicao =
                    PosicaoChegada == 1 ? 25D
                    : PosicaoChegada == 2 ? 18D
                    : PosicaoChegada == 3 ? 15D
                    : PosicaoChegada == 4 ? 12D
                    : PosicaoChegada == 5 ? 10D
                    : PosicaoChegada == 6 ? 8D
                    : PosicaoChegada == 7 ? 6D
                    : PosicaoChegada == 8 ? 4D
                    : PosicaoChegada == 9 ? 2D
                    : PosicaoChegada == 10 ? 1D
                    : 0D;

                if (CorridaMetadePontos) pontosPosicao /= 2;

                int pontoExtra = VoltaMaisRapida && PosicaoChegada <= 10 ? 1 : 0;

                return pontosPosicao + pontoExtra;
            }
        }

        private ResultadoLista()
        {
            Piloto = string.Empty;
            Equipe = string.Empty;
        }

        public ResultadoLista(int id, string piloto, string equipe, bool corridaMetadePontos, int posicaoLargada, int posicaoChegada, double pontosClassificacao, double pontosCorrida, bool voltaMaisRapida, bool dnf, bool dsq, bool grifar)
        {
            Id = id;
            Piloto = piloto;
            Equipe = equipe;
            CorridaMetadePontos = corridaMetadePontos;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            PontosClassificacao = pontosClassificacao;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;
            GrifarPontosCorrida = false;
            GrifarPontosClassificacao = false;
            GrifarChegada = false;
            GrifarLargada = false;
            GrifarEquipe = false;
        }
    }
}
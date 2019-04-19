using Formula1.Data.Entities;

namespace Formula1.Data.Models
{
    public class ResultadoInclusaoModel
    {
        public ResultadoInclusaoModel(int id, Corrida corrida, Piloto piloto, Equipe equipe, int posicaoLargada, int posicaoChegada, int pontos, bool pontoExtra = false, MotivoDNF? motivoDnf = null)
        {
            Id = id;
            CorridaId = corrida.Id;
            PilotoId = piloto.Id;
            EquipeId = equipe.Id;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            Pontos = pontos;
            PontoExtra = pontoExtra;
            DNF = motivoDnf != null;
            MotivoDNF = motivoDnf;
        }

        public int Id { get; set; }

        public int CorridaId { get; set; }

        public int PilotoId { get; set; }

        public int EquipeId { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public MotivoDNF? MotivoDNF { get; set; }
    }
}
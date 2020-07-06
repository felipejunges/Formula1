using Formula1.Data.Entities;

namespace Formula1.Data.Models
{
    public class ResultadoInclusao
    {
        public int Id { get; set; }

        public int CorridaId { get; set; }

        public int PilotoId { get; set; }

        public int EquipeId { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public ResultadoInclusao()
        {
        }

        public ResultadoInclusao(Resultado resultado)
        {
            Id = resultado.Id;
            CorridaId = resultado.CorridaId;
            PilotoId = resultado.PilotoId;
            EquipeId = resultado.EquipeId;
            PosicaoLargada = resultado.PosicaoLargada;
            PosicaoChegada = resultado.PosicaoChegada;
            Pontos = resultado.Pontos;
            PontoExtra = resultado.PontoExtra;
            DNF = resultado.DNF;
        }
    }
}
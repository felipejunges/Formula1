using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class PilotoTemporadaExportacao
    {
        public int Id { get; private set; }

        public int PilotoId { get; private set; }

        public int Temporada { get; private set; }

        public double Pontos { get; private set; }

        public int Posicao { get; private set; }

        public int PosicaoMaxima { get; private set; }

        public PilotoTemporadaExportacao(PilotoTemporada pilotoTemporada)
        {
            Id = pilotoTemporada.Id;
            PilotoId = pilotoTemporada.Piloto.Id;
            Temporada = pilotoTemporada.Temporada;
            Pontos = pilotoTemporada.Pontos;
            Posicao = pilotoTemporada.Posicao;
            PosicaoMaxima = pilotoTemporada.PosicaoMaxima;
        }
    }
}
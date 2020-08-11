namespace Formula1.Data.Models
{
    public class PilotoTemporadaInclusao
    {
        public int PilotoId { get; set; }

        public int Temporada { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        public PilotoTemporadaInclusao(int pilotoId, int temporada, int pontos, int posicao)
        {
            PilotoId = pilotoId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}
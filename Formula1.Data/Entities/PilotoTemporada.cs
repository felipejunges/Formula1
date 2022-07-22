namespace Formula1.Data.Entities
{
    public class PilotoTemporada : Entity
    {
        public int PilotoId { get; private set; }

        public Piloto Piloto { get; private set; }

        public int Temporada { get; private set; }

        public double Pontos { get; private set; }

        public int Posicao { get; private set; }

        public int PosicaoMaxima { get; private set; }

        public PilotoTemporada() : this(default, default, default, default, default, default)
        {
        }

        public PilotoTemporada(int pilotoId, int temporada) : this(default, pilotoId, temporada, default, default, default)
        {
        }

        public PilotoTemporada(int id, int pilotoId, int temporada, double pontos, int posicao, int posicaoMaxima)
        {
            Id = id;
            PilotoId = pilotoId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
            PosicaoMaxima = posicaoMaxima;

            Piloto = null!;
        }

        public void Atualizar(double pontos, int posicao, int posicaoMaxima)
        {
            Pontos = pontos;
            Posicao = posicao;
            PosicaoMaxima = posicaoMaxima;
        }
    }
}
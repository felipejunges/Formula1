namespace Formula1.Data.Entities
{
    public class EquipeTemporada : Entity
    {
        public int EquipeId { get; private set; }

        public Equipe Equipe { get; private set; }

        public int Temporada { get; private set; }

        public double Pontos { get; private set; }

        public int Posicao { get; private set; }

        public int PosicaoMaxima { get; private set; }

        public EquipeTemporada() : this(default, default, default, default, default, default)
        {
        }

        public EquipeTemporada(int equipeId, int temporada) : this(default, equipeId, temporada, default, default, default)
        {
        }

        public EquipeTemporada(int id, int equipeId, int temporada, double pontos, int posicao, int posicaoMaxima)
        {
            Id = id;
            EquipeId = equipeId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
            PosicaoMaxima = posicaoMaxima;

            Equipe = null!;
        }

        public void Atualizar(double pontos, int posicao, int posicaoMaxima)
        {
            Pontos = pontos;
            Posicao = posicao;
            PosicaoMaxima = posicaoMaxima;
        }
    }
}
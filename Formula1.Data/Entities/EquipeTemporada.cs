namespace Formula1.Data.Entities
{
    public class EquipeTemporada : Entity
    {
        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        public EquipeTemporada()
        {

        }

        public EquipeTemporada(int equipeId, int temporada, int pontos, int posicao)
        {
            Equipe = new Equipe() { Id = equipeId };
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}
namespace Formula1.Data.Entities
{
    public class EquipeTemporada : Entity
    {
        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public double Pontos { get; set; }

        public int Posicao { get; set; }

        public int PosicaoMaxima { get; set; }

        public EquipeTemporada()
        {
            Equipe = null!;
        }
    }
}
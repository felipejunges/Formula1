namespace Formula1.Data.Entities
{
    public class PilotoTemporada : Entity
    {
        public Piloto Piloto { get; set; }

        public int Temporada { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }
    }
}
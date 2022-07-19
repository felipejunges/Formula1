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
            // TODO: pensar sobre: Equipe = new();
            // Pq o Ef nao vai usar esse construtor
            // Se um dia for feito um "New" desta entidade, deverão ser passados os parâmetros
        }
    }
}
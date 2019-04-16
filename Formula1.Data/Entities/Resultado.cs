namespace Formula1.Data.Entities
{
    public class Resultado : Entity
    {
        public Resultado() { }

        public Resultado(int id, Corrida corrida, Piloto piloto, Equipe equipe, int posicaoLargada, int posicaoChegada, int pontos, MotivoDNF? motivoDnf = null)
        {
            Id = id;
            Corrida = corrida;
            Piloto = piloto;
            Equipe = equipe;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            Pontos = pontos;
            DNF = motivoDnf != null;
            MotivoDNF = motivoDnf;
        }

        public Corrida Corrida { get; set; }

        public Piloto Piloto { get; set; }

        public Equipe Equipe { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        public bool DNF { get; set; }
        
        public MotivoDNF? MotivoDNF { get; set; }
    }
}
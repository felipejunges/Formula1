namespace Formula1.Data.Models
{
    public class EquipeTemporadaInclusao
    {
        public int EquipeId { get; set; }

        public int Temporada { get; set; }

        public double Pontos { get; set; }

        public int Posicao { get; set; }

        public EquipeTemporadaInclusao(int equipeId, int temporada, double pontos, int posicao)
        {
            EquipeId = equipeId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}
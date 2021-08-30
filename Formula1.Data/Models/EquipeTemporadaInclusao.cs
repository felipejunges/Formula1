namespace Formula1.Data.Models
{
    public class EquipeTemporadaInclusao
    {
        public int EquipeId { get; set; }

        public int Temporada { get; set; }

        public decimal Pontos { get; set; }

        public int Posicao { get; set; }

        public EquipeTemporadaInclusao(int equipeId, int temporada, decimal pontos, int posicao)
        {
            EquipeId = equipeId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}
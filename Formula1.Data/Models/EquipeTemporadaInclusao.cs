namespace Formula1.Data.Models
{
    public class EquipeTemporadaInclusao
    {
        public int EquipeId { get; set; }

        public int Temporada { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        public EquipeTemporadaInclusao(int equipeId, int temporada, int pontos, int posicao)
        {
            EquipeId = equipeId;
            Temporada = temporada;
            Pontos = pontos;
            Posicao = posicao;
        }
    }
}
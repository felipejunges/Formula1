using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class EquipeTemporadaExportacao
    {
        public int Id { get; private set; }

        public int EquipeId { get; private set; }

        public int Temporada { get; private set; }

        public double Pontos { get; private set; }

        public int Posicao { get; private set; }

        public int PosicaoMaxima { get; private set; }

        public EquipeTemporadaExportacao(EquipeTemporada equipeTemporada)
        {
            Id = equipeTemporada.Id;
            EquipeId = equipeTemporada.Equipe.Id;
            Temporada = equipeTemporada.Temporada;
            Pontos = equipeTemporada.Pontos;
            Posicao = equipeTemporada.Posicao;
            PosicaoMaxima = equipeTemporada.PosicaoMaxima;
        }
    }
}
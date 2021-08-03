namespace Formula1.Data.Models
{
    public class ResultadoTemporada
    {
        public int PilotoId { get; set; }

        public int EquipeId { get; set; }

        public int CorridaId { get; set; }

        public int Pontos { get; set; }

        public bool PontoExtra { get; set; }

        public int PosicaoChegada { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }
    }
}
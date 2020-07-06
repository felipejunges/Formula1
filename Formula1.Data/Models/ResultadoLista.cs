namespace Formula1.Data.Models
{
    public class ResultadoLista
    {
        public int Id { get; set; }

        public string Piloto { get; set; }

        public string Equipe { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }
    }
}
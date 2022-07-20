namespace Formula1.Data.Entities
{
    public class Resultado : Entity
    {
        public int CorridaId { get; set; }

        public virtual Corrida Corrida { get; set; }

        public int PilotoId { get; set; }

        public virtual Piloto Piloto { get; set; }

        public int EquipeId { get; set; }

        public virtual Equipe Equipe { get; set; }

        public int PosicaoLargada { get; set; }

        public int PosicaoChegada { get; set; }

        public double PontosClassificacao { get; set; }

        public double PontosCorrida { get; set; }

        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public Resultado()
        {
            Corrida = null!;
            Piloto = null!;
            Equipe = null!;
        }
    }
}
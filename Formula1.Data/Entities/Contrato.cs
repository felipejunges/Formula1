namespace Formula1.Data.Entities
{
    public class Contrato : Entity
    {
        public Contrato()
        {
        }

        public int PilotoId { get; set; }

        public Piloto Piloto { get; set; }

        public int EquipeId { get; set; }

        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }
    }
}
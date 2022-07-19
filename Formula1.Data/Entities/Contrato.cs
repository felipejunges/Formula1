namespace Formula1.Data.Entities
{
    public class Contrato : Entity
    {
        public int PilotoId { get; set; }

        public virtual Piloto Piloto { get; set; }

        public int EquipeId { get; set; }

        public virtual Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public Contrato()
        {
        }
    }
}
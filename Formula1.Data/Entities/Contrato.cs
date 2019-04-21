namespace Formula1.Data.Entities
{
    public class Contrato : Entity
    {
        public Piloto Piloto { get; set; }

        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public Contrato() { }

        public Contrato(int id, Piloto piloto, Equipe equipe, int temporada)
            : this()
        {
            Id = id;
            Piloto = piloto;
            Equipe = equipe;
            Temporada = temporada;
        }
    }
}
namespace Formula1.Data.Entities
{
    public class Punicao : Entity
    {
        public Piloto Piloto { get; set; }

        public Equipe Equipe { get; set; }

        public int Temporada { get; set; }

        public string Descricao { get; set; }

        public int Pontos { get; set; }
    }
}
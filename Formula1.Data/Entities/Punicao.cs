namespace Formula1.Data.Entities
{
    public class Punicao : Entity
    {
        public int CorridaId { get; set; }

        public Corrida Corrida { get; set; }

        public int? PilotoId { get; set; }

        public Piloto Piloto { get; set; }

        public int? EquipeId { get; set; }

        public Equipe Equipe { get; set; }

        public string Descricao { get; set; }

        public int Pontos { get; set; }
    }
}
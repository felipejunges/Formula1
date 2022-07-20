namespace Formula1.Data.Entities
{
    public class Punicao : Entity
    {
        public int CorridaId { get; set; }

        public virtual Corrida Corrida { get; set; }

        public int? PilotoId { get; set; }

        public virtual Piloto? Piloto { get; set; }

        public int? EquipeId { get; set; }

        public virtual Equipe? Equipe { get; set; }

        public string Descricao { get; set; }

        public int Pontos { get; set; }

        public Punicao()
        {
            Corrida = null!;

            Descricao = string.Empty;
        }
    }
}
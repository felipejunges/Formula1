namespace Formula1.Data.Entities
{
    public class Punicao : Entity
    {
        public int CorridaId { get; private set; }

        public virtual Corrida Corrida { get; private set; }

        public int? PilotoId { get; private set; }

        public virtual Piloto? Piloto { get; private set; }

        public int? EquipeId { get; private set; }

        public virtual Equipe? Equipe { get; private set; }

        public string Descricao { get; private set; }

        public int Pontos { get; private set; }

        public Punicao() : this(0, 0, null, null, string.Empty, 0)
        {
        }

        public Punicao(int id, int corridaId, int? pilotoId, int? equipeId, string descricao, int pontos)
        {
            Id = id;
            CorridaId = corridaId;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            Descricao = descricao;
            Pontos = pontos;

            Corrida = null!;
        }
    }
}
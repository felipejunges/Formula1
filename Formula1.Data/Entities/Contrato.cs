namespace Formula1.Data.Entities
{
    public class Contrato : Entity
    {
        public int PilotoId { get; private set; }

        public virtual Piloto Piloto { get; private set; }

        public int EquipeId { get; private set; }

        public virtual Equipe Equipe { get; private set; }

        public int Temporada { get; private set; }

        public Contrato() : this(0, 0, 0)
        {
        }

        public Contrato(int pilotoId, int equipeId, int temporada)
        {
            PilotoId = pilotoId;
            EquipeId = equipeId;
            Temporada = temporada;

            Piloto = null!;
            Equipe = null!;
        }

        public void Atualizar(int pilotoId, int equipeId, int temporada)
        {
            PilotoId = pilotoId;
            EquipeId = equipeId;
            Temporada = temporada;
        }
    }
}
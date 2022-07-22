namespace Formula1.Data.Entities
{
    public class Resultado : Entity
    {
        public int CorridaId { get; private set; }

        public virtual Corrida Corrida { get; private set; }

        public int PilotoId { get; private set; }

        public virtual Piloto Piloto { get; private set; }

        public int EquipeId { get; private set; }

        public virtual Equipe Equipe { get; private set; }

        public int PosicaoLargada { get; private set; }

        public int PosicaoChegada { get; private set; }

        public double PontosClassificacao { get; private set; }

        public double PontosCorrida { get; private set; }

        public bool VoltaMaisRapida { get; private set; }

        public bool DNF { get; private set; }

        public bool DSQ { get; private set; }

        public Resultado() : this(0, 0, 0, 0, 0, 0, 0, 0, false, false, false)
        {
        }

        public Resultado(int id, int corridaId, int pilotoId, int equipeId, int posicaoLargada, int posicaoChegada, double pontosClassificacao, double pontosCorrida, bool voltaMaisRapida, bool dnf, bool dsq)
        {
            Id = id;
            CorridaId = corridaId;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            PontosClassificacao = pontosClassificacao;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;

            Corrida = null!;
            Piloto = null!;
            Equipe = null!;
        }

        public void Atualizar(int corridaId, int pilotoId, int equipeId, int posicaoLargada, int posicaoChegada, double pontosClassificacao, double pontosCorrida, bool voltaMaisRapida, bool dnf, bool dsq)
        {
            CorridaId = corridaId;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            PosicaoLargada = posicaoLargada;
            PosicaoChegada = posicaoChegada;
            PontosClassificacao = pontosClassificacao;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;
        }
    }
}
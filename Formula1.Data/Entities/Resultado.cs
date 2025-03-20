using System;
using Formula1.Data.ValueObjects.CalculosPontos;
using Formula1.Data.ValueObjects.CalculosPontos.Base;

namespace Formula1.Data.Entities
{
    public class Resultado : Entity
    {
        public int CorridaId { get; private set; }
        
        public bool Sprint { get; private set; }

        public virtual Corrida Corrida { get; private set; }

        public int PilotoId { get; private set; }

        public virtual Piloto Piloto { get; private set; }

        public int EquipeId { get; private set; }

        public virtual Equipe Equipe { get; private set; }

        public int PosicaoChegada { get; private set; }

        public double PontosCorrida { get; private set; }

        public bool VoltaMaisRapida { get; private set; }

        public bool DNF { get; private set; }

        public bool DSQ { get; private set; }

        public Resultado() : this(0, 0, false, 0, 0, 0, 0, false, false, false)
        {
        }

        public Resultado(int id, int corridaId, bool sprint, int pilotoId, int equipeId, int posicaoChegada, double pontosCorrida, bool voltaMaisRapida, bool dnf, bool dsq)
        {
            Id = id;
            CorridaId = corridaId;
            Sprint = sprint;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            PosicaoChegada = posicaoChegada;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;

            Corrida = null!;
            Piloto = null!;
            Equipe = null!;
        }

        public void Atualizar(int corridaId, bool sprint, int pilotoId, int equipeId, int posicaoChegada, double pontosCorrida, bool voltaMaisRapida, bool dnf, bool dsq)
        {
            CorridaId = corridaId;
            Sprint = sprint;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            PosicaoChegada = posicaoChegada;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;
        }
    }
}
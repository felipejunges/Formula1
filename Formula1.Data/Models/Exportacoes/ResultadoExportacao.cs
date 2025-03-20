using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class ResultadoExportacao
    {
        public int Id { get; private set; }

        public int CorridaId { get; private set; }

        public bool Sprint { get; private set; }

        public int PilotoId { get; private set; }

        public int EquipeId { get; private set; }

        public int PosicaoChegada { get; private set; }

        public double PontosCorrida { get; private set; }

        public bool VoltaMaisRapida { get; private set; }

        public bool DNF { get; private set; }

        public bool DSQ { get; private set; }

        public ResultadoExportacao()
        {
        }

        public ResultadoExportacao(Resultado resultado)
        {
            Id = resultado.Id;
            CorridaId = resultado.CorridaId;
            Sprint = resultado.Sprint;
            PilotoId = resultado.PilotoId;
            EquipeId = resultado.EquipeId;
            PosicaoChegada = resultado.PosicaoChegada;
            PontosCorrida = resultado.PontosCorrida;
            VoltaMaisRapida = resultado.VoltaMaisRapida;
            DNF = resultado.DNF;
            DSQ = resultado.DSQ;
        }

        public Resultado MapResultado()
        {
            return new Resultado(
                Id,
                CorridaId,
                Sprint,
                PilotoId,
                EquipeId,
                PosicaoChegada,
                PontosCorrida,
                VoltaMaisRapida,
                DNF,
                DSQ);
        }
    }
}
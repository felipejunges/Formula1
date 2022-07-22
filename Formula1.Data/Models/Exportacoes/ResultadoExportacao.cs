using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class ResultadoExportacao
    {
        public int Id { get; private set; }

        public int CorridaId { get; private set; }

        public int PilotoId { get; private set; }

        public int EquipeId { get; private set; }

        public int PosicaoLargada { get; private set; }

        public int PosicaoChegada { get; private set; }

        public double PontosClassificacao { get; private set; }

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
            PilotoId = resultado.PilotoId;
            EquipeId = resultado.EquipeId;
            PosicaoLargada = resultado.PosicaoLargada;
            PosicaoChegada = resultado.PosicaoChegada;
            PontosClassificacao = resultado.PontosClassificacao;
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
                PilotoId,
                EquipeId,
                PosicaoLargada,
                PosicaoChegada,
                PontosClassificacao,
                PontosCorrida,
                VoltaMaisRapida,
                DNF,
                DSQ);
        }
    }
}
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class ContratoExportacao
    {
        public int Id { get; private set; }

        public int PilotoId { get; private set; }

        public int EquipeId { get; private set; }

        public int Temporada { get; private set; }

        public ContratoExportacao()
        {
        }

        public ContratoExportacao(Contrato contrato)
        {
            Id = contrato.Id;
            PilotoId = contrato.PilotoId;
            EquipeId = contrato.EquipeId;
            Temporada = contrato.Temporada;
        }

        public Contrato MapContrato()
        {
            return new Contrato(
                temporada: Temporada,
                pilotoId: PilotoId,
                equipeId: EquipeId);
        }
    }
}
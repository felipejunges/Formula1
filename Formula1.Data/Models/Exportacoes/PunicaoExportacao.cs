using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class PunicaoExportacao
    {
        public int Id { get; private set; }

        public int CorridaId { get; private set; }

        public int? PilotoId { get; private set; }

        public int? EquipeId { get; private set; }

        public string Descricao { get; private set; }

        public int Pontos { get; private set; }

        public PunicaoExportacao()
        {
            Descricao = string.Empty;
        }

        public PunicaoExportacao(Punicao punicao)
        {
            Id = punicao.Id;
            CorridaId = punicao.CorridaId;
            PilotoId = punicao.PilotoId;
            EquipeId = punicao.EquipeId;
            Descricao = punicao.Descricao;
            Pontos = punicao.Pontos;
        }

        public Punicao MapPunicao()
        {
            return new Punicao(
                Id,
                CorridaId,
                PilotoId,
                EquipeId,
                Descricao,
                Pontos);
        }
    }
}
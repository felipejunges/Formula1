using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Contratos
{
    public class ContratoDados
    {
        public int Id { get; set; }

        public int Temporada { get; set; }

        public int PilotoId { get; set; }

        public int EquipeId { get; set; }

        public ContratoDados()
        {

        }

        public ContratoDados(Contrato contato)
        {
            Id = contato.Id;
            Temporada = contato.Temporada;
            PilotoId = contato.PilotoId;
            EquipeId = contato.EquipeId;
        }
    }
}
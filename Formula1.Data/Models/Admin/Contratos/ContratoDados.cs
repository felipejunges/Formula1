using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Contratos
{
    public class ContratoDados
    {
        public int Id { get; set; }

        public int Temporada { get; set; }

        [Display(Name = "Piloto")]
        public int PilotoId { get; set; }

        [Display(Name = "Equipe")]
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
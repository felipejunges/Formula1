using Formula1.Data.Entities;

namespace Formula1.Data.Models
{
    public class ContratoInclusao
    {
        public int Id { get; set; }

        public int PilotoId { get; set; }

        public int EquipeId { get; set; }

        public int Temporada { get; set; }

        public ContratoInclusao(int id, Piloto piloto, Equipe equipe, int temporada)
        {
            Id = id;
            PilotoId = piloto.Id;
            EquipeId = equipe.Id;
            Temporada = temporada;
        }
    }
}
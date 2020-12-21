using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Pilotos
{
    public class PilotoDados
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Nome de guerra")]
        public string NomeGuerra { get; set; }

        [Required]
        public string Sigla { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int? NumeroCarro { get; set; }

        [Required]
        [Display(Name = "País origem")]
        public string PaisOrigem { get; set; }

        public PilotoDados()
        {

        }

        public PilotoDados(Piloto piloto)
        {
            Id = piloto.Id;
            Nome = piloto.Nome;
            NomeGuerra = piloto.NomeGuerra;
            Sigla = piloto.Sigla;
            NumeroCarro = piloto.NumeroCarro;
            PaisOrigem = piloto.PaisOrigem;
        }
    }
}
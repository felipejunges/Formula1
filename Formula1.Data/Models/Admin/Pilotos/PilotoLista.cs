using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Pilotos
{
    public class PilotoLista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Nome de guerra")]
        public string NomeGuerra { get; set; }

        public string Sigla { get; set; }

        [Display(Name = "Número")]
        public int NumeroCarro { get; set; }

        [Display(Name = "País origem")]
        public string PaisOrigem { get; set; }

        public bool Ativo { get; set; }

        public PilotoLista()
        {

        }

        public PilotoLista(Piloto piloto)
        {
            Id = piloto.Id;
            Nome = piloto.Nome;
            NomeGuerra = piloto.NomeGuerra;
            Sigla = piloto.Sigla;
            NumeroCarro = piloto.NumeroCarro;
            PaisOrigem = piloto.PaisOrigem;
            Ativo = piloto.Ativo;
        }
    }
}
using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Pilotos
{
    public class PilotoLista
    {
        public int Id { get; init; }

        public string Nome { get; init; }

        [Display(Name = "Nome de guerra")]
        public string NomeGuerra { get; init; }

        public string Sigla { get; init; }

        [Display(Name = "Número")]
        public int NumeroCarro { get; init; }

        [Display(Name = "País origem")]
        public string PaisOrigem { get; init; }

        public bool Ativo { get; init; }

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
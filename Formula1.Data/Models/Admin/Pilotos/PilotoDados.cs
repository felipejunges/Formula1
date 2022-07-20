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

        public bool Ativo { get; set; }

        public static PilotoDados Novo()
        {
            return new PilotoDados(
                id: 0,
                nome: string.Empty,
                nomeGuerra: string.Empty,
                sigla: string.Empty,
                numeroCarro: default,
                paisOrigem: string.Empty,
                ativo: true
            );
        }

        public PilotoDados()
        {
            Nome = string.Empty;
            NomeGuerra = string.Empty;
            Sigla = string.Empty;
            PaisOrigem = string.Empty;
        }

        public PilotoDados(int id, string nome, string nomeGuerra, string sigla, int? numeroCarro, string paisOrigem, bool ativo)
        {
            Id = id;
            Nome = nome;
            NomeGuerra = nomeGuerra;
            Sigla = sigla;
            NumeroCarro = numeroCarro;
            PaisOrigem = paisOrigem;
            Ativo = ativo;
        }

        public PilotoDados(Piloto piloto)
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
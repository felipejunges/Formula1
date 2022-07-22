using Formula1.Data.Entities;
using System.Text.Json.Serialization;

namespace Formula1.Data.Models.Exportacoes
{
    public class PilotoExportacao
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string NomeGuerra { get; private set; }

        public string Sigla { get; private set; }

        public int NumeroCarro { get; private set; }

        public string PaisOrigem { get; private set; }

        public bool Ativo { get; private set; }

        public PilotoExportacao()
        {
            Nome = string.Empty;
            NomeGuerra = string.Empty;
            Sigla = string.Empty;
            PaisOrigem = string.Empty;
        }

        public PilotoExportacao(Piloto piloto)
        {
            Id = piloto.Id;
            Nome = piloto.Nome;
            NomeGuerra = piloto.NomeGuerra;
            Sigla = piloto.Sigla;
            NumeroCarro = piloto.NumeroCarro;
            PaisOrigem = piloto.PaisOrigem;
            Ativo = piloto.Ativo;
        }

        public Piloto MapPiloto()
        {
            return new Piloto(
                Id,
                Nome,
                NomeGuerra,
                Sigla,
                NumeroCarro,
                PaisOrigem,
                Ativo);
        }
    }
}
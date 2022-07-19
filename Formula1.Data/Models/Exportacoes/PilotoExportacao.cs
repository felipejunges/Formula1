using Formula1.Data.Entities;

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
    }
}
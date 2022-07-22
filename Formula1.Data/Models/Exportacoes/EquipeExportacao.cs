using Formula1.Data.Entities;

namespace Formula1.Data.Models.Exportacoes
{
    public class EquipeExportacao
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string CorRgb { get; private set; }

        public bool Ativo { get; private set; }

        public EquipeExportacao()
        {
            Nome = string.Empty;
            CorRgb = string.Empty;
        }

        public EquipeExportacao(Equipe equipe)
        {
            Id = equipe.Id;
            Nome = equipe.Nome;
            CorRgb = equipe.CorRgb;
            Ativo = equipe.Ativo;
        }

        public Equipe MapEquipe()
        {
            return new Equipe(
                Id,
                Nome,
                CorRgb,
                Ativo);
        }
    }
}
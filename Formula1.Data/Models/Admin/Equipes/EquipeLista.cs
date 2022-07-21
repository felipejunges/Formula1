using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Equipes
{
    public class EquipeLista
    {
        public int Id { get; init; }

        public string Nome { get; init; } = string.Empty;

        [Display(Name = "Cor RGB")]
        public string CorRgb { get; init; } = string.Empty;

        public bool Ativo { get; init; }

        public EquipeLista(Equipe equipe)
        {
            Id = equipe.Id;
            Nome = equipe.Nome;
            CorRgb = equipe.CorRgb;
            Ativo = equipe.Ativo;
        }
    }
}
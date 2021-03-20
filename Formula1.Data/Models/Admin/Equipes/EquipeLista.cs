using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Equipes
{
    public class EquipeLista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Cor RGB")]
        public string CorRgb { get; set; }

        public bool Ativo { get; set; }

        public EquipeLista()
        {

        }

        public EquipeLista(Equipe equipe)
        {
            Id = equipe.Id;
            Nome = equipe.Nome;
            CorRgb = equipe.CorRgb;
            Ativo = equipe.Ativo;
        }
    }
}
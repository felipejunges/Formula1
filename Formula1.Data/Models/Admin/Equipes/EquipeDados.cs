using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Equipes
{
    public class EquipeDados
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cor RGB")]
        public string CorRgb { get; set; }

        public bool Ativo { get; set; }

        public EquipeDados()
        {

        }

        public EquipeDados(Equipe equipe)
        {
            Id = equipe.Id;
            Nome = equipe.Nome;
            CorRgb = equipe.CorRgb;
            Ativo = equipe.Ativo;
        }
    }
}
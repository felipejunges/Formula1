using System.ComponentModel.DataAnnotations;
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoDados
    {
        public int Id { get; set; }

        public int CorridaId { get; set; }
        
        [Display(Name = "Piloto")]
        public int PilotoId { get; set; }

        [Display(Name = "Equipe")]
        public int EquipeId { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        [Required]
        public double? Pontos { get; set; }

        [Display(Name = "Ponto extra")]
        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public ResultadoDados()
        {
        }

        public ResultadoDados(Resultado resultado)
        {
            Id = resultado.Id;
            CorridaId = resultado.CorridaId;
            PilotoId = resultado.PilotoId;
            EquipeId = resultado.EquipeId;
            PosicaoLargada = resultado.PosicaoLargada;
            PosicaoChegada = resultado.PosicaoChegada;
            Pontos = resultado.Pontos;
            PontoExtra = resultado.PontoExtra;
            DNF = resultado.DNF;
            DSQ = resultado.DSQ;
        }
    }
}
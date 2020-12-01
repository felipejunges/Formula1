using Formula1.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin
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

        public int Pontos { get; set; }

        [Display(Name = "Ponto extra")]
        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

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
        }
    }
}
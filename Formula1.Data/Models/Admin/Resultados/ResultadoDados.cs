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
        [Display(Name = "Pontos classificação")]
        public double? PontosClassificacao { get; set; }

        [Required]
        [Display(Name = "Pontos corrida")]
        public double? PontosCorrida { get; set; }

        [Display(Name = "Volta mais rápida")]
        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public static ResultadoDados NovoResultado(int corridaId)
        {
            return new ResultadoDados() { Id = 0, CorridaId = corridaId };
        }

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
            PontosClassificacao = resultado.PontosClassificacao;
            PontosCorrida = resultado.PontosCorrida;
            VoltaMaisRapida = resultado.VoltaMaisRapida;
            DNF = resultado.DNF;
            DSQ = resultado.DSQ;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Formula1.Data.Entities;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoDados
    {
        public int Id { get; private set; }

        public int CorridaId { get; private set; }

        [Display(Name = "Piloto")]
        public int PilotoId { get; private set; }

        [Display(Name = "Equipe")]
        public int EquipeId { get; private set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; private set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; private set; }

        public double? PontosClassificacao { get; private set; }

        [Required]
        public double? PontosCorrida { get; private set; }

        [Display(Name = "Volta mais rápida")]
        public bool VoltaMaisRapida { get; private set; }

        public bool DNF { get; private set; }

        public bool DSQ { get; private set; }

        public static ResultadoDados NovoResultado(int corridaId)
        {
            return new ResultadoDados() { Id = 0, CorridaId = corridaId };
        }

        private ResultadoDados()
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
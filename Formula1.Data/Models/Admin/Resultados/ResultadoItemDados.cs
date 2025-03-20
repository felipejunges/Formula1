using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoItemDados
    {
        public int? IdAtual { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        [Display(Name = "Piloto")]
        public int? PilotoId { get; set; }

        [Display(Name = "Equipe")]
        public int? EquipeId { get; set; }

        [Display(Name = "Pts. corrida")]
        public double PontosCorrida { get; set; }

        [Display(Name = "Vlt. + rápida")]
        public bool VoltaMaisRapida { get; set; }

        public bool DNF { get; set; }

        public bool DSQ { get; set; }

        public bool GrifarPontosCorrida { get; set; }

        public bool GrifarChegada { get; set; }

        public bool GrifarPiloto { get; set; }

        public bool GrifarEquipe { get; set; }

        public bool DeveExcluirItem => IdAtual.HasValue && !DevePersistirItem;

        public bool DevePersistirItem => PilotoId.HasValue && EquipeId.HasValue;

        public ResultadoItemDados()
        {
        }

        public ResultadoItemDados(
            int? id,
            int posicaoChegada,
            int? pilotoId,
            int? equipeId,
            double pontosCorrida,
            bool voltaMaisRapida,
            bool dnf,
            bool dsq)
        {
            IdAtual = id;
            PosicaoChegada = posicaoChegada;
            PilotoId = pilotoId;
            EquipeId = equipeId;
            PontosCorrida = pontosCorrida;
            VoltaMaisRapida = voltaMaisRapida;
            DNF = dnf;
            DSQ = dsq;
            GrifarPontosCorrida = false;
            GrifarChegada = false;
            GrifarPiloto = false;
            GrifarEquipe = false;
        }
    }
}
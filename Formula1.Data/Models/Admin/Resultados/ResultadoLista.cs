using System.ComponentModel.DataAnnotations;

namespace Formula1.Data.Models.Admin.Resultados
{
    public class ResultadoLista
    {
        public int Id { get; set; }

        public string Piloto { get; set; }

        public string Equipe { get; set; }

        [Display(Name = "Pos. largada")]
        public int PosicaoLargada { get; set; }

        [Display(Name = "Pos. chegada")]
        public int PosicaoChegada { get; set; }

        public int Pontos { get; set; }

        [Display(Name = "Ponto extra")]
        public bool PontoExtra { get; set; }

        public bool DNF { get; set; }

        public bool Grifar { get; set; }
    }
}
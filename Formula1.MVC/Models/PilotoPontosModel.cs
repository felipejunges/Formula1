using Formula1.Data.Entities;

namespace Formula1.MVC.Models
{
    public class PilotoPontosModel
    {
        public Piloto Piloto { get; set; }

        public int Pontos { get; set; }

        public PilotoPontosModel(Piloto piloto, int pontos)
        {
            Piloto = piloto;
            Pontos = pontos;
        }
    }
}
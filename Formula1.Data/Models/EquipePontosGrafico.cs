namespace Formula1.Data.Models
{
    public class EquipePontosGrafico
    {
        public string Equipe { get; set; } = string.Empty;

        public string CorRgb { get; set; } = string.Empty;

        public double?[] Pontos { get; set; } = new double?[0];
    }
}
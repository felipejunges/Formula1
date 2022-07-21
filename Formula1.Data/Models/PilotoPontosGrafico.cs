namespace Formula1.Data.Models
{
    public class PilotoPontosGrafico
    {
        public string Piloto { get; init; } = string.Empty;

        public string CorRgb { get; init; } = string.Empty;

        public double?[] Pontos { get; init; } = new double?[0];
    }
}
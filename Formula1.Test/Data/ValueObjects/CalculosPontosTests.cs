using Formula1.Data.ValueObjects.CalculosPontos.Factories;

namespace Formula1.Test.Data.ValueObjects;

public class CalculosPontosTests
{
    [Theory]
    [InlineData(2025, 25)]
    [InlineData(2024, 26)]
    [InlineData(2021, 26)]
    [InlineData(2020, 26)]
    [InlineData(2019, 26)]
    public void MaximoPontosPilotoGPDeveSerCorreto(int temporada, double pontosMaximosEsperados)
    {
        var calculoPontos = CalculoPontosFactory.CriarCalculoPontos(temporada, false);
        
        Assert.Equal(pontosMaximosEsperados, calculoPontos.MaximoPontosPiloto);
    }
    
    [Theory]
    [InlineData(2025, 8)]
    [InlineData(2024, 8)]
    [InlineData(2021, 3)]
    [InlineData(2020, 0)]
    [InlineData(2019, 0)]
    public void MaximoPontosPilotoSprintDeveSerCorreto(int temporada, double pontosMaximosEsperados)
    {
        var calculoPontos = CalculoPontosFactory.CriarCalculoPontos(temporada, true);
        
        Assert.Equal(pontosMaximosEsperados, calculoPontos.MaximoPontosPiloto);
    }
    
    [Theory]
    [InlineData(2025, 43)]
    [InlineData(2024, 44)]
    [InlineData(2021, 44)]
    [InlineData(2020, 44)]
    [InlineData(2019, 44)]
    public void MaximoPontosEquipeGPDeveSerCorreto(int temporada, double pontosMaximosEsperados)
    {
        var calculoPontos = CalculoPontosFactory.CriarCalculoPontos(temporada, false);
        
        Assert.Equal(pontosMaximosEsperados, calculoPontos.MaximoPontosEquipe);
    }
    
    [Theory]
    [InlineData(2025, 15)]
    [InlineData(2024, 15)]
    [InlineData(2021, 5)]
    [InlineData(2020, 0)]
    [InlineData(2019, 0)]
    public void MaximoPontosEquipeSprintDeveSerCorreto(int temporada, double pontosMaximosEsperados)
    {
        var calculoPontos = CalculoPontosFactory.CriarCalculoPontos(temporada, true);
        
        Assert.Equal(pontosMaximosEsperados, calculoPontos.MaximoPontosEquipe);
    }
}
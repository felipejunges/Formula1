using Formula1.Data.Entities;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Domain.Services;
using Moq;

namespace Formula1.Test.Domain.Services;

public class CorridasServiceTests
{
    private readonly CorridasService _service;

    private readonly Mock<ICorridasRepository> _corridasRepository;
    
    public CorridasServiceTests()
    {
        _corridasRepository = new Mock<ICorridasRepository>();
        
        _service = new CorridasService(_corridasRepository.Object);
    }

    [Theory]
    [InlineData(2025, 25)]
    [InlineData(2024, 26)]
    [InlineData(2022, 26)]
    [InlineData(2021, 26)]
    [InlineData(2020, 26)]
    [InlineData(2019, 26)]
    public void MaximoPontosPilotoGPDeveSerCorreto(int temporada, int pontosMaximosEsperados)
    {
        // Arrange
        var corrida = new Corrida(1, temporada, 1, "Teste", "Teste", DateTime.Now, false, false);
        
        _corridasRepository
            .Setup(s => s.ObterCorridasRestantes(temporada))
            .Returns(new List<Corrida> { corrida });
        
        // Act
        var pontos = _service.GetPontosEmDisputaPilotos(temporada);

        // Assert
        Assert.Equal(pontosMaximosEsperados, pontos);
    }
    
    [Theory]
    [InlineData(2025, 33)]
    [InlineData(2024, 34)]
    [InlineData(2022, 34)]
    [InlineData(2021, 29)]
    [InlineData(2020, 26)]
    [InlineData(2019, 26)]
    public void MaximoPontosPilotoSprintDeveSerCorreto(int temporada, int pontosMaximosEsperados)
    {
        // Arrange
        var corrida = new Corrida(1, temporada, 1, "Teste", "Teste", DateTime.Now, true, false);
        
        _corridasRepository
            .Setup(s => s.ObterCorridasRestantes(temporada))
            .Returns(new List<Corrida> { corrida });
        
        // Act
        var pontos = _service.GetPontosEmDisputaPilotos(temporada);

        // Assert
        Assert.Equal(pontosMaximosEsperados, pontos);
    }
    
    [Theory]
    [InlineData(2025, 43)]
    [InlineData(2024, 44)]
    [InlineData(2022, 44)]
    [InlineData(2021, 44)]
    [InlineData(2020, 44)]
    [InlineData(2019, 44)]
    public void MaximoPontosEquipeGPDeveSerCorreto(int temporada, int pontosMaximosEsperados)
    {
        // Arrange
        var corrida = new Corrida(1, temporada, 1, "Teste", "Teste", DateTime.Now, false, false);
        
        _corridasRepository
            .Setup(s => s.ObterCorridasRestantes(temporada))
            .Returns(new List<Corrida> { corrida });
        
        // Act
        var pontos = _service.GetPontosEmDisputaEquipes(temporada);

        // Assert
        Assert.Equal(pontosMaximosEsperados, pontos);
    }
    
    [Theory]
    [InlineData(2025, 58)]
    [InlineData(2024, 59)]
    [InlineData(2022, 59)]
    [InlineData(2021, 49)]
    [InlineData(2020, 44)]
    [InlineData(2019, 44)]
    public void MaximoPontosEquipeSprintDeveSerCorreto(int temporada, int pontosMaximosEsperados)
    {
        // Arrange
        var corrida = new Corrida(1, temporada, 1, "Teste", "Teste", DateTime.Now, true, false);
        
        _corridasRepository
            .Setup(s => s.ObterCorridasRestantes(temporada))
            .Returns(new List<Corrida> { corrida });
        
        // Act
        var pontos = _service.GetPontosEmDisputaEquipes(temporada);

        // Assert
        Assert.Equal(pontosMaximosEsperados, pontos);
    }
}
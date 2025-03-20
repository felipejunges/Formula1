using Formula1.Domain.Interfaces.Repositories;
using System.Linq;
using Formula1.Data.ValueObjects.CalculosPontos.Base;
using Formula1.Data.ValueObjects.CalculosPontos.Factories;

namespace Formula1.Domain.Services
{
    public class CorridasService
    {
        private readonly ICorridasRepository _corridasRepository;

        public CorridasService(ICorridasRepository corridasRepository)
        {
            _corridasRepository = corridasRepository;
        }

        public double GetPontosEmDisputaPilotos(int temporada)
        {
            var calculoGPS = CalculoPontosFactory.CriarCalculoPontos(temporada, false);
            var calculoSprints = CalculoPontosFactory.CriarCalculoPontos(temporada, true);
            
            var corridasRestantes = _corridasRepository.ObterCorridasRestantes(temporada);

            return corridasRestantes.Sum(s =>
                calculoGPS.MaximoPontosPiloto
                + (s.CorridaSprint ? calculoSprints.MaximoPontosPiloto : 0));
        }

        public double GetPontosEmDisputaEquipes(int temporada)
        {
            var calculoGPS = CalculoPontosFactory.CriarCalculoPontos(temporada, false);
            var calculoSprints = CalculoPontosFactory.CriarCalculoPontos(temporada, true);
            
            var corridasRestantes = _corridasRepository.ObterCorridasRestantes(temporada);
            
            return corridasRestantes.Sum(s =>
                calculoGPS.MaximoPontosEquipe
                + (s.CorridaSprint ? calculoSprints.MaximoPontosEquipe : 0));
        }
    }
}
using Formula1.Domain.Interfaces.Repositories;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class CorridasService
    {
        private readonly ICorridasRepository _corridasRepository;

        public CorridasService(ICorridasRepository corridasRepository)
        {
            _corridasRepository = corridasRepository;
        }

        public int GetPontosEmDisputaPilotos(int temporada)
        {
            var corridasRestantes = _corridasRepository.ObterCorridasRestantes(temporada);

            return corridasRestantes.Sum(s =>
                s.CorridaClassificacao
                    ? temporada < 2022 ? 29 : 34
                    : 26);
        }

        public int GetPontosEmDisputaEquipes(int temporada)
        {
            var corridasRestantes = _corridasRepository.ObterCorridasRestantes(temporada);

            return corridasRestantes.Sum(s =>
                s.CorridaClassificacao
                    ? temporada < 2022 ? 49 : 59
                    : 44);
        }
    }
}
using Formula1.Data.Entities;
using System.Collections.Generic;

namespace Formula1.Infra.Database.Mock
{
    public class MockDatabase
    {
        public ICollection<Corrida> GerarCorridasTemporada2019()
        {
            var corridas = CorridasMock.Corridas;

            ResultadosMock.PreencherResultados998(corridas);

            return corridas;
        }
    }
}
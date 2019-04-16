using Formula1.Data.Entities;
using Formula1.Infra.Database.Mock;
using System.Collections.Generic;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        public ICollection<Corrida> GetCorridas2019()
        {
            return new MockDatabase().GerarCorridasTemporada2019();
        }
    }
}
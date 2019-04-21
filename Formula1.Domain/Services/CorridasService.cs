using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class CorridasService
    {
        private readonly F1Db Db;

        public CorridasService(F1Db db)
        {
            Db = db;
        }

        public List<CorridaTemporada> GetCorridasTabela(int temporada)
        {
            var corridas = Db.Corridas.Where(o => o.Temporada == temporada).OrderBy(o => o.DataHoraBrasil).Select(o => new CorridaTemporada()
            {
                Id = o.Id,
                DataHoraBrasil = o.DataHoraBrasil,
                NomeGrandePremio = o.NomeGrandePremio
            }).ToList();

            return corridas;
        }
    }
}
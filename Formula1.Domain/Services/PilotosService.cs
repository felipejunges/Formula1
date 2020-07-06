using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PilotosService
    {
        private readonly F1Db Db;

        public PilotosService(F1Db db)
        {
            Db = db;
        }

        public List<PilotoTemporada> ObterPilotosTabela(int temporada)
        {
            var pilotos = (from c in Db.Contratos
                           join p in Db.Pilotos on c.Piloto equals p
                           join e in Db.Equipes on c.Equipe equals e
                           where c.Temporada == temporada
                           select new PilotoTemporada()
                           {
                               Id = p.Id,
                               NomeGuerra = p.NomeGuerra,
                               CorRgb = e.CorRgb
                           }).ToList();

            return pilotos;
        }
    }
}
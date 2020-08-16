using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
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

        public List<Piloto> ObterPilotosContrato(int temporada)
        {
            var pilotos = this.Db.Contratos.Where(o => o.Temporada == temporada).Select(o => o.Piloto).ToList();

            return pilotos;
        }

        public List<PilotoTemporadaResultado> ObterPilotosTabela(int temporada)
        {
            var pilotos = (from pt in Db.PilotosTemporada
                           join p in Db.Pilotos on pt.Piloto equals p
                           where pt.Temporada == temporada
                           select new PilotoTemporadaResultado()
                           {
                               Id = p.Id,
                               NomeGuerra = p.NomeGuerra,
                               CorRgb = p.Contratos.Where(o => o.Temporada == temporada).OrderByDescending(o => o.Id).FirstOrDefault().Equipe.CorRgb,
                               Pontos = pt.Pontos,
                               Posicao = pt.Posicao
                           }).ToList();

            return pilotos;
        }
    }
}
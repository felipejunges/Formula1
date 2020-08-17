using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PunicaoService
    {
        private readonly F1Db Db;

        public PunicaoService(F1Db db)
        {
            Db = db;
        }

        public List<PunicaoTemporada> ObterPunicoesTemporada(int temporada)
        {
            return Db.Punicoes
                .Where(o => o.Temporada == temporada)
                .Select(o => new PunicaoTemporada()
                {
                    PilotoId = o.Piloto != null ? o.Piloto.Id : (int?)null,
                    EquipeId = o.Equipe != null ? o.Equipe.Id : (int?)null,
                    Pontos = o.Pontos
                })
                .ToList();
        }
    }
}
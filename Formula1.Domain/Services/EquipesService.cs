using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class EquipesService
    {
        private readonly F1Db Db;

        public EquipesService(F1Db db)
        {
            Db = db;
        }

        public List<EquipeTemporada> GetEquipesTabela(int temporada)
        {
            var equipes = (from c in Db.Contratos
                           join e in Db.Equipes on c.Equipe equals e
                           where c.Temporada == temporada
                           group e by new { e.Id, e.Nome } into g
                           select new EquipeTemporada()
                           {
                               Id = g.Key.Id,
                               Nome = g.Key.Nome
                           }).ToList();

            return equipes;
        }
    }
}
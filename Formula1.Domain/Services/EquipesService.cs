using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database;
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

        public List<Equipe> ObterEquipesContrato(int temporada)
        {
            var equipes = this.Db.Contratos.Where(o => o.Temporada == temporada).Select(o => o.Equipe).ToList().GroupBy(o => o).Select(o => o.Key).ToList();

            return equipes;
        }

        public List<EquipeTemporadaResultado> ObterEquipesTabela(int temporada)
        {
            var equipes = (from et in Db.EquipesTemporada
                           join e in Db.Equipes on et.Equipe equals e
                           where et.Temporada == temporada
                           select new EquipeTemporadaResultado()
                           {
                               Id = e.Id,
                               Nome = e.Nome,
                               CorRgb = e.CorRgb,
                               Pontos = et.Pontos,
                               Posicao = et.Posicao
                           }).ToList();

            return equipes;
        }
    }
}
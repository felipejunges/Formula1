using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class EquipesTemporadaRepository : IEquipesTemporadaRepository
    {
        private readonly F1Db Db;

        public EquipesTemporadaRepository(F1Db db)
        {
            Db = db;
        }

        public void AddOrUpdate(EquipeTemporadaInclusao equipeTemporadaInclusao)
        {
            var equipeTemporada = Db.EquipesTemporada.Where(o => o.Temporada == equipeTemporadaInclusao.Temporada && o.Equipe.Id == equipeTemporadaInclusao.EquipeId).FirstOrDefault();

            if (equipeTemporada == null)
                equipeTemporada = new EquipeTemporada(equipeTemporadaInclusao.EquipeId, equipeTemporadaInclusao.Temporada);

            equipeTemporada.Atualizar(
                equipeTemporadaInclusao.Pontos,
                equipeTemporadaInclusao.Posicao,
                equipeTemporadaInclusao.PosicaoMaxima);

            if (equipeTemporada.Id == 0)
                Db.EquipesTemporada.Add(equipeTemporada);
            else
                Db.EquipesTemporada.Update(equipeTemporada);

            Db.SaveChanges();
        }
    }
}
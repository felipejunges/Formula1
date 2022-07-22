using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class PilotosTemporadaRepository : IPilotosTemporadaRepository
    {
        private readonly F1Db Db;

        public PilotosTemporadaRepository(F1Db db)
        {
            Db = db;
        }

        public void AddOrUpdate(PilotoTemporadaInclusao pilotoTemporadaInclusao)
        {
            var pilotoTemporada = Db.PilotosTemporada.Where(o => o.Temporada == pilotoTemporadaInclusao.Temporada && o.Piloto.Id == pilotoTemporadaInclusao.PilotoId).FirstOrDefault();

            if (pilotoTemporada == null)
                pilotoTemporada = new PilotoTemporada(pilotoTemporadaInclusao.PilotoId, pilotoTemporadaInclusao.Temporada);

            pilotoTemporada.Atualizar(
                pilotoTemporadaInclusao.Pontos,
                pilotoTemporadaInclusao.Posicao,
                pilotoTemporadaInclusao.PosicaoMaxima);

            if (pilotoTemporada.Id == 0)
                Db.PilotosTemporada.Add(pilotoTemporada);
            else
                Db.PilotosTemporada.Update(pilotoTemporada);

            Db.SaveChanges();
        }
    }
}
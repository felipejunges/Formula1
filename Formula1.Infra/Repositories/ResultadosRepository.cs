using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Infra.Repositories
{
    public class ResultadosRepository : IResultadosRepository
    {
        private readonly F1Db Db;

        public ResultadosRepository(F1Db db)
        {
            Db = db;
        }

        public Resultado? ObterPeloId(int id)
        {
            return Db.Resultados.Find(id);
        }

        public List<ResultadoTemporadaPiloto> GetResultadosPilotosTemporada(int temporada)
        {
            var resultados = (from r in Db.Resultados
                              join c in Db.Corridas on r.CorridaId equals c.Id
                              where
                                  c.Temporada == temporada
                              select new ResultadoTemporadaPiloto()
                              {
                                  PilotoId = r.PilotoId,
                                  CorridaId = r.CorridaId,
                                  Sprint = r.Sprint,
                                  Pontos = r.PontosCorrida,
                                  VoltaMaisRapida = r.VoltaMaisRapida,
                                  PosicaoChegada = r.PosicaoChegada,
                                  DNF = r.DNF,
                                  DSQ = r.DSQ
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.Pontos -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.PilotoId == r.PilotoId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoTemporadaEquipe> GetResultadosEquipeTemporada(int temporada)
        {
            var resultados = (from r in Db.Resultados
                              join c in Db.Corridas on r.CorridaId equals c.Id
                              where
                                  c.Temporada == temporada
                              group r by new
                              {
                                  r.EquipeId,
                                  r.CorridaId,
                                  r.Sprint
                              } into g
                              select new ResultadoTemporadaEquipe()
                              {
                                  EquipeId = g.Key.EquipeId,
                                  CorridaId = g.Key.CorridaId,
                                  Sprint = g.Key.Sprint,
                                  PontosTotais = g.Sum(s => s.PontosCorrida),
                                  VoltaMaisRapida = g.Max(m => m.VoltaMaisRapida ? 1 : 0) > 0,
                                  MelhorPosicaoChegada = g.Min(m => m.PosicaoChegada)
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.PontosTotais -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.EquipeId == r.EquipeId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoItemDados> ObterListaResultados(int corridaId, bool sprint)
        {
            return Db.Resultados
                .Include(r => r.Corrida)
                .Where(o => 
                    o.Corrida.Id == corridaId 
                    && o.Sprint == sprint)
                .OrderBy(o => o.PosicaoChegada)
                .Select(o => new ResultadoItemDados(
                    o.Id,
                    o.PosicaoChegada,
                    o.PilotoId,
                    o.EquipeId,
                    o.PontosCorrida,
                    o.VoltaMaisRapida,
                    o.DNF,
                    o.DSQ
                 ))
                .ToList();
        }

        public void Incluir(Resultado resultado)
        {
            Db.Resultados.Add(resultado);
            Db.SaveChanges();
        }

        public void Alterar(Resultado resultado)
        {
            Db.Resultados.Update(resultado);
            Db.SaveChanges();
        }

        public void Excluir(Resultado resultado)
        {
            Db.Resultados.Remove(resultado);
            Db.SaveChanges();
        }
    }
}
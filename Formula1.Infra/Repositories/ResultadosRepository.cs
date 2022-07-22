using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
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

        public List<ResultadoTemporada> GetResultadosPilotosTemporada(int temporada)
        {
            var resultados = (from r in Db.Resultados
                              join c in Db.Corridas on r.CorridaId equals c.Id
                              where
                                  c.Temporada == temporada
                              select new ResultadoTemporada()
                              {
                                  PilotoId = r.PilotoId,
                                  EquipeId = 0,
                                  CorridaId = r.CorridaId,
                                  PontosTotais = r.PontosClassificacao + r.PontosCorrida,
                                  VoltaMaisRapida = r.VoltaMaisRapida,
                                  PosicaoChegada = r.PosicaoChegada,
                                  DNF = r.DNF,
                                  DSQ = r.DSQ
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.PontosTotais -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.PilotoId == r.PilotoId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoTemporada> GetResultadosEquipeTemporada(int temporada)
        {
            var resultados = (from r in Db.Resultados
                              join c in Db.Corridas on r.CorridaId equals c.Id
                              where
                                  c.Temporada == temporada
                              group r by new
                              {
                                  r.EquipeId,
                                  r.CorridaId
                              } into g
                              select new ResultadoTemporada()
                              {
                                  PilotoId = 0,
                                  EquipeId = g.Key.EquipeId,
                                  CorridaId = g.Key.CorridaId,
                                  PontosTotais = g.Sum(s => s.PontosClassificacao + s.PontosCorrida),
                                  VoltaMaisRapida = g.Max(m => m.VoltaMaisRapida ? 1 : 0) > 0,
                                  PosicaoChegada = g.Min(m => m.PosicaoChegada),
                                  DNF = false,
                                  DSQ = false
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.PontosTotais -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.EquipeId == r.EquipeId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoLista> ObterListaResultados(int corridaId)
        {
            return Db.Resultados
                .Where(o => o.Corrida.Id == corridaId)
                .OrderBy(o => o.PosicaoChegada)
                .ThenBy(o => o.PosicaoLargada)
                .Select(o => new ResultadoLista(
                    o.Id,
                    o.Piloto.Nome,
                    o.Equipe.Nome,
                    o.Corrida.MetadePontos,
                    o.PosicaoLargada,
                    o.PosicaoChegada,
                    o.PontosClassificacao,
                    o.PontosCorrida,
                    o.VoltaMaisRapida,
                    o.DNF,
                    o.DSQ,
                    false
                 ))
                .ToList();
        }

        public void Incluir(ResultadoDados resultadoDados)
        {
            var resultado = new Resultado()
            {
                Id = 0,
                CorridaId = resultadoDados.CorridaId,
                PilotoId = resultadoDados.PilotoId!.Value,
                EquipeId = resultadoDados.EquipeId!.Value,
                PosicaoLargada = resultadoDados.PosicaoLargada,
                PosicaoChegada = resultadoDados.PosicaoChegada,
                PontosClassificacao = resultadoDados.PontosClassificacao!.Value,
                PontosCorrida = resultadoDados.PontosCorrida!.Value,
                VoltaMaisRapida = resultadoDados.VoltaMaisRapida,
                DNF = resultadoDados.DNF,
                DSQ = resultadoDados.DSQ
            };

            Db.Resultados.Add(resultado);
            Db.SaveChanges();
        }

        public void Alterar(ResultadoDados resultadoDados)
        {
            var resultado = ObterPeloId(resultadoDados.Id);

            if (resultado is null)
                return;

            resultado.CorridaId = resultadoDados.CorridaId;
            resultado.PilotoId = resultadoDados.PilotoId!.Value;
            resultado.EquipeId = resultadoDados.EquipeId!.Value;
            resultado.PosicaoLargada = resultadoDados.PosicaoLargada;
            resultado.PosicaoChegada = resultadoDados.PosicaoChegada;
            resultado.PontosClassificacao = resultadoDados.PontosClassificacao!.Value;
            resultado.PontosCorrida = resultadoDados.PontosCorrida!.Value;
            resultado.VoltaMaisRapida = resultadoDados.VoltaMaisRapida;
            resultado.DNF = resultadoDados.DNF;
            resultado.DSQ = resultadoDados.DSQ;

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
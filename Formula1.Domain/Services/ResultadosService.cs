using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Resultados;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class ResultadosService
    {
        private readonly F1Db Db;

        public ResultadosService(F1Db db)
        {
            Db = db;
        }

        public Resultado ObterPeloId(int id)
        {
            var resultado = Db.Resultados.Find(id);

            return resultado;
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
                                  Pontos = r.Pontos,
                                  PontoExtra = r.PontoExtra,
                                  PosicaoChegada = r.PosicaoChegada,
                                  DNF = r.DNF
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.Pontos -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.PilotoId == r.PilotoId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoTemporada> GetResultadosEquipeTemporada(int temporada)
        {
            var resultados = (from r in Db.Resultados
                              join c in Db.Corridas on r.CorridaId equals c.Id
                              where
                                  c.Temporada == temporada
                              group new { r } by new
                              {
                                  r.EquipeId,
                                  r.CorridaId
                              } into g
                              select new ResultadoTemporada()
                              {
                                  PilotoId = 0,
                                  EquipeId = g.Key.EquipeId,
                                  CorridaId = g.Key.CorridaId,
                                  Pontos = g.Sum(s => s.r.Pontos),
                                  PontoExtra = g.Max(m => m.r.PontoExtra ? 1 : 0) > 0,
                                  PosicaoChegada = g.Min(m => m.r.PosicaoChegada),
                                  DNF = false
                              }).ToList();

            var punicoes = Db.Punicoes.Where(o => o.Corrida.Temporada == temporada).ToList();

            resultados.ForEach(r => r.Pontos -= punicoes.Where(w => w.CorridaId == r.CorridaId && w.EquipeId == r.EquipeId).Sum(s => s.Pontos));

            return resultados;
        }

        public List<ResultadoLista> ObterListaResultados(int corridaId)
        {
            var resultados = Db.Resultados
                .Where(o => o.Corrida.Id == corridaId)
                .OrderBy(o => o.PosicaoChegada)
                .ThenBy(o => o.PosicaoLargada)
                .Select(o => new ResultadoLista(
                    o.Id,
                    o.Piloto.Nome,
                    o.Equipe.Nome,
                    o.Corrida.CorridaClassificacao,
                    o.PosicaoLargada,
                    o.PosicaoChegada,
                    o.Pontos,
                    o.PontoExtra,
                    o.DNF,
                    false
                 ))
                .ToList();

            GrifarItensListaInvalidos(resultados);

            return resultados;
        }

        private void GrifarItensListaInvalidos(List<ResultadoLista> resultados)
        {
            //
            resultados.Where(o => o.Pontos != o.PontosCalculados).ToList().ForEach(o => o.Grifar = true);

            //
            resultados.Where(r => r.PosicaoLargada == 0 || r.PosicaoChegada == 0).ToList().ForEach(r => r.Grifar = true);

            //
            var posicoesLargadaRepetidos = resultados.GroupBy(o => o.PosicaoLargada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoLargada = resultados.Where(o => posicoesLargadaRepetidos.Contains(o.PosicaoLargada)).ToList();

            itensPosicaoLargada.ForEach(o => o.Grifar = true);

            //
            var posicoesChegadaRepetidos = resultados.GroupBy(o => o.PosicaoChegada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoChegada = resultados.Where(o => posicoesChegadaRepetidos.Contains(o.PosicaoChegada)).ToList();

            itensPosicaoChegada.ForEach(o => o.Grifar = true);

            //
            var equipesMais2Resultados = resultados.GroupBy(o => o.Equipe).Where(o => o.Count() > 2).Select(o => o.Key).ToList();

            var equipesGrifar = resultados.Where(o => equipesMais2Resultados.Contains(o.Equipe)).ToList();

            equipesGrifar.ForEach(o => o.Grifar = true);
        }

        public void Incluir(ResultadoDados resultadoDados)
        {
            var resultado = new Resultado()
            {
                Id = 0,
                CorridaId = resultadoDados.CorridaId,
                PilotoId = resultadoDados.PilotoId,
                EquipeId = resultadoDados.EquipeId,
                PosicaoLargada = resultadoDados.PosicaoLargada,
                PosicaoChegada = resultadoDados.PosicaoChegada,
                Pontos = resultadoDados.Pontos,
                PontoExtra = resultadoDados.PontoExtra,
                DNF = resultadoDados.DNF
            };

            Db.Resultados.Add(resultado);
            Db.SaveChanges();
        }

        public void Alterar(ResultadoDados resultadoDados)
        {
            var resultado = ObterPeloId(resultadoDados.Id);

            resultado.CorridaId = resultadoDados.CorridaId;
            resultado.PilotoId = resultadoDados.PilotoId;
            resultado.EquipeId = resultadoDados.EquipeId;
            resultado.PosicaoLargada = resultadoDados.PosicaoLargada;
            resultado.PosicaoChegada = resultadoDados.PosicaoChegada;
            resultado.Pontos = resultadoDados.Pontos;
            resultado.PontoExtra = resultadoDados.PontoExtra;
            resultado.DNF = resultadoDados.DNF;

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
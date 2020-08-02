using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System;
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
            var resultados = Db.Resultados
                .Where(o => o.Corrida.Temporada == temporada)
                .Select(o => new ResultadoTemporada()
                {
                    PilotoId = o.Piloto.Id,
                    EquipeId = 0,
                    CorridaId = o.Corrida.Id,
                    Pontos = o.Pontos,
                    PontoExtra = o.PontoExtra,
                    PosicaoChegada = o.PosicaoChegada,
                    DNF = o.DNF
                }).ToList();

            return resultados;
        }

        public List<ResultadoTemporada> GetResultadosEquipeTemporada(int temporada)
        {
            var resultados = Db.Resultados
                .Where(o => o.Corrida.Temporada == temporada)
                .GroupBy(o => new { EquipeId = o.Equipe.Id, CorridaId = o.Corrida.Id })
                .Select(o => new ResultadoTemporada()
                {
                    PilotoId = 0,
                    EquipeId = o.Key.EquipeId,
                    CorridaId = o.Key.CorridaId,
                    Pontos = o.Sum(s => s.Pontos),
                    PontoExtra = o.Max(m => m.PontoExtra ? 1 : 0) > 0,
                    PosicaoChegada = o.Min(m => m.PosicaoChegada),
                    DNF = false
                }).ToList();

            return resultados;
        }

        public List<ResultadoLista> ObterListaResultados(int corridaId)
        {
            var resultados = Db.Resultados
                .Where(o => o.Corrida.Id == corridaId)
                .OrderBy(o => o.PosicaoChegada)
                .Select(o => new ResultadoLista()
                {
                    Id = o.Id,
                    Piloto = o.Piloto.Nome,
                    Equipe = o.Equipe.Nome,
                    PosicaoLargada = o.PosicaoLargada,
                    PosicaoChegada = o.PosicaoChegada,
                    Pontos = o.Pontos,
                    PontoExtra = o.PontoExtra,
                    DNF = o.DNF
                }).ToList();

            return resultados;
        }

        public void Incluir(ResultadoInclusao resultadoInclusao)
        {
            var resultado = new Resultado()
            {
                Id = 0,
                CorridaId = resultadoInclusao.CorridaId,
                PilotoId = resultadoInclusao.PilotoId,
                EquipeId = resultadoInclusao.EquipeId,
                PosicaoLargada = resultadoInclusao.PosicaoLargada,
                PosicaoChegada = resultadoInclusao.PosicaoChegada,
                Pontos = resultadoInclusao.Pontos,
                PontoExtra = resultadoInclusao.PontoExtra,
                DNF = resultadoInclusao.DNF
            };

            Db.Resultados.Add(resultado);
            Db.SaveChanges();
        }

        public void Alterar(ResultadoInclusao resultadoInclusao)
        {
            var resultado = ObterPeloId(resultadoInclusao.Id);

            resultado.CorridaId = resultadoInclusao.CorridaId;
            resultado.PilotoId = resultadoInclusao.PilotoId;
            resultado.EquipeId = resultadoInclusao.EquipeId;
            resultado.PosicaoLargada = resultadoInclusao.PosicaoLargada;
            resultado.PosicaoChegada = resultadoInclusao.PosicaoChegada;
            resultado.Pontos = resultadoInclusao.Pontos;
            resultado.PontoExtra = resultadoInclusao.PontoExtra;
            resultado.DNF = resultadoInclusao.DNF;

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
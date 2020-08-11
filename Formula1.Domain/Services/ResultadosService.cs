using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                    DNF = o.DNF,
                    Grifar = false
                }).ToList();

            GrifarItensListaInvalidos(resultados);

            return resultados;
        }

        private void GrifarItensListaInvalidos(List<ResultadoLista> resultados)
        {
            //
            var itensPontosInvalidos = resultados.Where(o =>
                    (o.PosicaoChegada == 1 && o.Pontos != 25 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 2 && o.Pontos != 18 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 3 && o.Pontos != 15 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 4 && o.Pontos != 12 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 5 && o.Pontos != 10 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 6 && o.Pontos != 8 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 7 && o.Pontos != 6 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 8 && o.Pontos != 4 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 9 && o.Pontos != 2 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 10 && o.Pontos != 1 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada > 10 && o.Pontos > 0)
                ).ToList();

            itensPontosInvalidos.ForEach(o => o.Grifar = true);

            //
            var posicoesLargadaRepetidos = resultados.GroupBy(o => o.PosicaoLargada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoLargada = resultados.Where(o => posicoesLargadaRepetidos.Contains(o.PosicaoLargada)).ToList();

            itensPosicaoLargada.ForEach(o => o.Grifar = true);

            //
            var posicoesChegadaRepetidos = resultados.GroupBy(o => o.PosicaoChegada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoChegada = resultados.Where(o => posicoesChegadaRepetidos.Contains(o.PosicaoChegada)).ToList();

            itensPosicaoChegada.ForEach(o => o.Grifar = true);
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
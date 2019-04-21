using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
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
                    PosicaoChegada = o.PosicaoChegada
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
                    PosicaoChegada = 0
                }).ToList();

            return resultados;
        }
    }
}
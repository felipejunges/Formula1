using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        private readonly F1Db Db;

        public TemporadaService(F1Db db)
        {
            Db = db;
        }

        public List<Corrida> GetCorridas(int temporada)
        {
            var corridas = Db.Corridas.Where(o => o.Temporada == temporada).OrderBy(o => o.DataHoraBrasil).ToList();

            return corridas;
        }

        public List<PilotoResultadosModel> GetPilotosResultados(int temporada)
        {
            var resultados = Db.Resultados
                .Include(o => o.Piloto)
                .Include(o => o.Corrida)
                .Where(o => o.Corrida.Temporada == temporada)
                .ToList();
            
            var pilotosResultados = new List<PilotoResultadosModel>();

            foreach (var resultado in resultados)
            {
                var pilotoResultado = pilotosResultados.Where(o => o.Piloto == resultado.Piloto.NomeGuerra).FirstOrDefault();

                if (pilotoResultado == null)
                    pilotosResultados.Add(new PilotoResultadosModel(resultado.Piloto.NomeGuerra, resultado.Corrida.Id, resultado.PosicaoChegada, resultado.Pontos));
                else
                    pilotoResultado.AddResultado(resultado.Corrida.Id, resultado.PosicaoChegada, resultado.Pontos);
            }

            pilotosResultados.Sort((o, i) => i.Pontos.CompareTo(o.Pontos));

            // TODO: gambiarra total, feio, e se tiverem mais do que 20 pilotos?
            var pilotosResultadosOrdenados = pilotosResultados
                    .OrderByDescending(o => o.Pontos)
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 1))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 2))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 3))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 4))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 5))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 6))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 7))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 8))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 9))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 10))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 11))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 12))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 13))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 14))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 15))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 16))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 17))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 18))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 19))
                    .ThenByDescending(o => o.Resultados.Count(c => c.Value == 20))
                    .ToList();

            return pilotosResultadosOrdenados;
        }

        public TabelaCampeonatoModel GetCampeonato(int temporada)
        {
            var corridas = GetCorridas(temporada);

            var pilotosResultados = GetPilotosResultados(temporada);

            return new TabelaCampeonatoModel(corridas, pilotosResultados);
        }
    }
}
using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        private F1Db Db;

        public TemporadaService(F1Db db)
        {
            Db = db;
        }

        public List<Corrida> GetCorridas(int temporada)
        {
            var corridas = Db.Corridas.Where(o => o.Temporada == temporada).OrderBy(o => o.DataHoraBrasil).ToList();

            return corridas;
        }

        public ResultadoCampeonatoModel GetCampeonato(int temporada)
        {
            var corridas = GetCorridas(temporada);

            List<PilotoPontosModel> pilotos = new List<PilotoPontosModel>();
            foreach (var corrida in corridas)
            {
                foreach (var resultado in corrida.Resultados)
                {
                    var pilotoPontos = pilotos.Where(o => o.Piloto == resultado.Piloto).FirstOrDefault();

                    if (pilotoPontos == null)
                        pilotos.Add(new PilotoPontosModel(resultado.Piloto, resultado.Pontos));
                    else
                        pilotoPontos.Pontos += resultado.Pontos;
                }
            }

            pilotos.Sort((o, i) => i.Pontos.CompareTo(o.Pontos));

            return new ResultadoCampeonatoModel(corridas, pilotos);
        }
    }
}
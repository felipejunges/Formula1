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

            return pilotosResultados;
        }

        public TabelaCampeonatoModel GetCampeonato(int temporada)
        {
            var corridas = GetCorridas(temporada);

            var pilotosResultados = GetPilotosResultados(temporada);

            return new TabelaCampeonatoModel(corridas, pilotosResultados);
        }
    }
}
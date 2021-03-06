﻿using Formula1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaPilotosService
    {
        private static readonly int PONTOS_MAXIMOS_CORRIDA_PILOTO = 26;

        private readonly CorridasService CorridasService;
        private readonly PilotosService PilotosService;
        private readonly ResultadosService ResultadosService;

        public TabelaPilotosService(CorridasService corridasService, PilotosService pilotosService, ResultadosService resultadosService)
        {
            CorridasService = corridasService;
            PilotosService = pilotosService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoPilotos GetTabelaCampeonatoPilotos(int temporada, int? corridaOrder)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.ObterPilotosTabela(temporada);
            var resultados = ResultadosService.GetResultadosPilotosTemporada(temporada);

            PreencherResultadosPilotosCorridas(corridas, pilotos, resultados);

            if (corridaOrder == null)
                pilotos.Sort((o, i) => o.Posicao.CompareTo(i.Posicao));
            else
                pilotos.Sort((o, i) =>
                        o.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value) == null ? 999 : o.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value).PosicaoChegada
                    .CompareTo(
                        i.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value) == null ? 999 : i.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value).PosicaoChegada
                    ));

            var pontosRestantes = CalcularPontosRestantes(corridas);
            MarcarPilotosPosicaoMaxima(pilotos, pontosRestantes);

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }

        private void PreencherResultadosPilotosCorridas(List<CorridaTemporada> corridas, List<PilotoTemporadaResultado> pilotos, List<ResultadoTemporada> resultados)
        {
            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }

        private void MarcarPilotosPosicaoMaxima(List<PilotoTemporadaResultado> pilotos, int pontosRestantes)
        {
            pilotos.ForEach(f =>
                    f.PosicaoMaxima = pilotos.IndexOf(pilotos.Where(w => w.Pontos <= f.Pontos + pontosRestantes).OrderByDescending(o => o.Pontos).FirstOrDefault()) + 1
                );
        }

        private int CalcularPontosRestantes(List<CorridaTemporada> corridas)
        {
            int corridasRestantes = corridas.Where(o => o.Resultados.Count() == 0).Count();
            int pontosRestantes = corridasRestantes * PONTOS_MAXIMOS_CORRIDA_PILOTO;

            return pontosRestantes;
        }
    }
}
 
﻿using Formula1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class GraficoCampeonatoEquipesService
    {
        private readonly TabelaEquipesService TabelaEquipesService;

        public GraficoCampeonatoEquipesService(TabelaEquipesService tabelaEquipesService)
        {
            TabelaEquipesService = tabelaEquipesService;
        }

        public GraficoCampeonatoEquipes GetGraficoCampeonatoEquipes(int temporada)
        {
            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(temporada, null);

            var equipesGrafico = new List<EquipePontosGrafico>();

            foreach (var equipe in campeonato.Equipes)
            {
                var pontos = new double?[campeonato.Corridas.Count];

                double soma = 0;
                foreach (var corrida in campeonato.Corridas)
                {
                    if (!corrida.TemResultadosDeCorrida)
                        break;

                    var resultado = equipe.Resultados.FirstOrDefault(o => o.CorridaId == corrida.Id);
                    if (resultado != null)
                        soma += resultado.PontosTotais;

                    pontos[campeonato.Corridas.IndexOf(corrida)] = soma;
                }

                equipesGrafico.Add(new EquipePontosGrafico()
                {
                    Equipe = equipe.Nome,
                    CorRgb = equipe.CorRgb,
                    Pontos = pontos
                });
            }

            var graficoCampeonatoEquipes = new GraficoCampeonatoEquipes(campeonato.Corridas, equipesGrafico, false);

            return graficoCampeonatoEquipes;
        }

        public GraficoCampeonatoEquipes GetGraficoPontosPorCorrida(int temporada)
        {
            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(temporada, null);

            var equipesGrafico = new List<EquipePontosGrafico>();

            foreach (var equipe in campeonato.Equipes)
            {
                var pontos = new double?[campeonato.Corridas.Count];

                foreach (var corrida in campeonato.Corridas)
                {
                    if (!corrida.TemResultadosDeCorrida)
                        break;

                    var resultado = equipe.Resultados.FirstOrDefault(o => o.CorridaId == corrida.Id);

                    pontos[campeonato.Corridas.IndexOf(corrida)] = resultado?.PontosTotais ?? 0;
                }

                equipesGrafico.Add(new EquipePontosGrafico()
                {
                    Equipe = equipe.Nome,
                    CorRgb = equipe.CorRgb,
                    Pontos = pontos
                });
            }

            var graficoCampeonatoEquipes = new GraficoCampeonatoEquipes(campeonato.Corridas, equipesGrafico, true);

            return graficoCampeonatoEquipes;
        }
    }
}
using Formula1.Data.Models;
using System.Collections.Generic;

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
            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(temporada);

            var equipesGrafico = new List<EquipePontosGrafico>();

            foreach (var equipe in campeonato.Equipes)
            {
                var pontos = new int?[campeonato.Corridas.Count];
                for (int i = 0; i < equipe.Resultados.Count; i++)
                    pontos[i] = i == 0 ? equipe.Resultados[i].Pontos : pontos[i - 1] + equipe.Resultados[i].Pontos;

                equipesGrafico.Add(new EquipePontosGrafico()
                {
                    Equipe = equipe.Nome,
                    CorRgb = equipe.CorRgb,
                    Pontos = pontos
                });
            }

            var graficoCampeonatoEquipes = new GraficoCampeonatoEquipes(campeonato.Corridas, equipesGrafico);

            return graficoCampeonatoEquipes;
        }
    }
}
using Formula1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaEquipesService
    {
        private static readonly int PONTOS_MAXIMOS_CORRIDA_EQUIPE = 44;

        private readonly CorridasService CorridasService;
        private readonly EquipesService EquipesService;
        private readonly ResultadosService ResultadosService;

        public TabelaEquipesService(CorridasService corridasService, EquipesService equipesService, ResultadosService resultadosService)
        {
            CorridasService = corridasService;
            EquipesService = equipesService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoEquipes GetTabelaCampeonatoEquipes(int temporada, int? corridaOrder)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var equipes = EquipesService.ObterEquipesTabela(temporada);
            var resultados = ResultadosService.GetResultadosEquipeTemporada(temporada);

            PreencherResultadosEquipesCorridas(corridas, equipes, resultados);

            if (corridaOrder == null)
                equipes.Sort((o, i) => o.Posicao.CompareTo(i.Posicao));
            else
                equipes.Sort((o, i) =>
                        i.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value) == null ? 0 : i.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value).Pontos
                    .CompareTo(
                        o.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value) == null ? 0 : o.Resultados.FirstOrDefault(c => c.CorridaId == corridaOrder.Value).Pontos
                    ));

            int pontosRestantes = CalcularPontosRestantes(corridas);
            MarcarEquipesPosicaoMaxima(equipes, pontosRestantes);

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }

        private void PreencherResultadosEquipesCorridas(List<CorridaTemporada> corridas, List<EquipeTemporadaResultado> equipes, List<ResultadoTemporada> resultados)
        {
            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }

        private void MarcarEquipesPosicaoMaxima(List<EquipeTemporadaResultado> equipes, int pontosRestantes)
        {
            equipes.ForEach(f =>
                    f.PosicaoMaxima = equipes.IndexOf(equipes.Where(w => w.Pontos <= f.Pontos + pontosRestantes).OrderByDescending(o => o.Pontos).FirstOrDefault()) + 1
                );
        }

        private static int CalcularPontosRestantes(List<CorridaTemporada> corridas)
        {
            int corridasRestantes = corridas.Where(o => o.Resultados.Count() == 0).Count();
            int pontosRestantes = corridasRestantes * PONTOS_MAXIMOS_CORRIDA_EQUIPE;
            return pontosRestantes;
        }
    }
}
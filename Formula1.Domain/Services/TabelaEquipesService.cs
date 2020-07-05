using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaEquipesService
    {
        private static int PONTOS_MAXIMOS_CORRIDA_EQUIPE = 44;

        private readonly CorridasService CorridasService;
        private readonly EquipesService EquipesService;
        private readonly ResultadosService ResultadosService;

        public TabelaEquipesService(CorridasService corridasService, EquipesService equipesService, ResultadosService resultadosService)
        {
            CorridasService = corridasService;
            EquipesService = equipesService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoEquipes GetTabelaCampeonatoEquipes(int temporada, int? order)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var equipes = EquipesService.GetEquipesTabela(temporada);
            var resultados = ResultadosService.GetResultadosEquipeTemporada(temporada);
            
            PreencherResultadosEquipesCorridas(corridas, equipes, resultados);

            if (order == null)
                equipes.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));
            else
                equipes.Sort((o, i) => i.Resultados[order.Value - 1].Pontos.CompareTo(o.Resultados[order.Value - 1].Pontos));

            int pontosRestantes = CalcularPontosRestantes(corridas);
            MarcarEquipesPosicaoMaxima(equipes, pontosRestantes);

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }

        private void PreencherResultadosEquipesCorridas(List<CorridaTemporada> corridas, List<EquipeTemporada> equipes, List<ResultadoTemporada> resultados)
        {
            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }

        private void MarcarEquipesPosicaoMaxima(List<EquipeTemporada> equipes, int pontosRestantes)
        {
            equipes.ForEach(f =>
                    f.PosicaoMaxima = equipes.IndexOf(equipes.Where(w => w.PontosTemporada <= f.PontosTemporada + pontosRestantes).OrderByDescending(o => o.PontosTemporada).FirstOrDefault()) + 1
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
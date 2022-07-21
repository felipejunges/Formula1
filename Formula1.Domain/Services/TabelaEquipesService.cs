using Formula1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaEquipesService
    {
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
                equipes.Sort((o, i) => OrdenarPorPontos(o.Resultados, i.Resultados, corridaOrder.Value));

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }

        private int OrdenarPorPontos(List<ResultadoTemporada> resultados1, List<ResultadoTemporada> resultados2, int corridaId)
        {
            var resultadoCorrida1 = resultados1.FirstOrDefault(c => c.CorridaId == corridaId);
            var resultadoCorrida2 = resultados2.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida1 == null && resultadoCorrida2 == null) return 0;
            if (resultadoCorrida1 != null && resultadoCorrida2 == null) return -1;
            if (resultadoCorrida1 == null && resultadoCorrida2 != null) return 1;

            return (resultadoCorrida2?.PontosTotais ?? 0).CompareTo((resultadoCorrida1?.PontosTotais ?? 0));
        }

        private void PreencherResultadosEquipesCorridas(List<CorridaTemporada> corridas, List<EquipeTemporadaResultado> equipes, List<ResultadoTemporada> resultados)
        {
            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }
    }
}
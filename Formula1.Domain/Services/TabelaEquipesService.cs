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
                equipes.Sort((o, i) => ObterPontosTotais(i.Resultados, corridaOrder.Value).CompareTo(ObterPontosTotais(o.Resultados, corridaOrder.Value)));

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }

        private double ObterPontosTotais(List<ResultadoTemporada> resultados, int corridaId)
        {
            var resultadoCorrida = resultados.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida == null) return 999;

            return resultadoCorrida.PontosTotais;
        }

        private void PreencherResultadosEquipesCorridas(List<CorridaTemporada> corridas, List<EquipeTemporadaResultado> equipes, List<ResultadoTemporada> resultados)
        {
            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }
    }
}
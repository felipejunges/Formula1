using Formula1.Data.Models;
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

        public TabelaCampeonatoEquipes GetTabelaCampeonatoEquipes(int temporada, int? order)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var equipes = EquipesService.GetEquipesTabela(temporada);
            var resultados = ResultadosService.GetResultadosEquipeTemporada(temporada);

            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());

            if (order == null)
                equipes.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));
            else
                equipes.Sort((o, i) => i.Resultados[order.Value - 1].Pontos.CompareTo(o.Resultados[order.Value - 1].Pontos));

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }
    }
}
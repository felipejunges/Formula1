using Formula1.Data.Models;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        private readonly CorridasService CorridasService;
        private readonly EquipesService EquipesService;
        private readonly PilotosService PilotosService;
        private readonly ResultadosService ResultadosService;

        public TemporadaService(CorridasService corridasService, EquipesService equipesService, PilotosService pilotosService, ResultadosService resultadosService)
        {
            CorridasService = corridasService;
            EquipesService = equipesService;
            PilotosService = pilotosService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoPilotosModel GetTabelaCampeonatoPilotos(int temporada)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.GetPilotosTabela(temporada);
            var resultados = ResultadosService.GetResultadosPilotosTemporada(temporada);

            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());

            pilotos.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));

            return new TabelaCampeonatoPilotosModel(corridas, pilotos);
        }

        public TabelaCampeonatoEquipesModel GetTabelaCampeonatoEquipes(int temporada)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var equipes = EquipesService.GetEquipesTabela(temporada);
            var resultados = ResultadosService.GetResultadosEquipeTemporada(temporada);

            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());

            equipes.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));

            return new TabelaCampeonatoEquipesModel(corridas, equipes);
        }
    }
}
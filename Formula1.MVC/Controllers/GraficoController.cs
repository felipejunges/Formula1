using Formula1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Controllers
{
    public class GraficoController : Controller
    {
        private readonly GraficoCampeonatoPilotosService GraficoCampeonatoPilotosService;
        private readonly GraficoCampeonatoEquipesService GraficoCampeonatoEquipesService;

        public GraficoController(GraficoCampeonatoPilotosService graficoCampeonatoPilotosService, GraficoCampeonatoEquipesService graficoCampeonatoEquipesService)
        {
            GraficoCampeonatoPilotosService = graficoCampeonatoPilotosService;
            GraficoCampeonatoEquipesService = graficoCampeonatoEquipesService;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos(int temporada)
        {
            var pilotosGrafico = GraficoCampeonatoPilotosService.GetGraficoCampeonatoPilotos(temporada);

            ViewData["Temporada"] = temporada;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos(int temporada)
        {
            var equipesGrafico = GraficoCampeonatoEquipesService.GetGraficoCampeonatoEquipes(temporada);

            ViewData["Temporada"] = temporada;

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PontosPilotosPorCorrida(int temporada)
        {
            var pilotosGrafico = GraficoCampeonatoPilotosService.GetGraficoPontosPorCorrida(temporada);

            ViewData["Temporada"] = temporada;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PontosEquipesPorCorrida(int temporada)
        {
            var equipesGrafico = GraficoCampeonatoEquipesService.GetGraficoPontosPorCorrida(temporada);

            ViewData["Temporada"] = temporada;

            return View(equipesGrafico);
        }
    }
}

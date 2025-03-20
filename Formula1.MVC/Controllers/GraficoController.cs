using Formula1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Controllers
{
    public class GraficoController : Controller
    {
        private readonly GraficoCampeonatoPilotosService _graficoCampeonatoPilotosService;
        private readonly GraficoCampeonatoEquipesService _graficoCampeonatoEquipesService;

        public GraficoController(GraficoCampeonatoPilotosService graficoCampeonatoPilotosService, GraficoCampeonatoEquipesService graficoCampeonatoEquipesService)
        {
            _graficoCampeonatoPilotosService = graficoCampeonatoPilotosService;
            _graficoCampeonatoEquipesService = graficoCampeonatoEquipesService;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos(int temporada)
        {
            var pilotosGrafico = _graficoCampeonatoPilotosService.GetGraficoCampeonatoPilotos(temporada);

            ViewData["Temporada"] = temporada;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos(int temporada)
        {
            var equipesGrafico = _graficoCampeonatoEquipesService.GetGraficoCampeonatoEquipes(temporada);

            ViewData["Temporada"] = temporada;

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PontosPilotosPorCorrida(int temporada)
        {
            var pilotosGrafico = _graficoCampeonatoPilotosService.GetGraficoPontosPorCorrida(temporada);

            ViewData["Temporada"] = temporada;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PontosEquipesPorCorrida(int temporada)
        {
            var equipesGrafico = _graficoCampeonatoEquipesService.GetGraficoPontosPorCorrida(temporada);

            ViewData["Temporada"] = temporada;

            return View(equipesGrafico);
        }
    }
}

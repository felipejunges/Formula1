using Formula1.Domain.Services;
using Formula1.Infra.Database.SqlServer;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const int TEMPORADA = 2019;

        private readonly TabelaPilotosService TabelaPilotosService;
        private readonly TabelaEquipesService TabelaEquipesService;
        private readonly GraficoCampeonatoPilotosService GraficoCampeonatoPilotosService;
        private readonly GraficoCampeonatoEquipesService GraficoCampeonatoEquipesService;

        public HomeController(F1Db db, TabelaPilotosService tabelaPilotosService, TabelaEquipesService tabelaEquipesService, GraficoCampeonatoPilotosService graficoCampeonatoPilotosService, GraficoCampeonatoEquipesService graficoCampeonatoEquipesService)
        {
            db.Database.EnsureCreated();

            TabelaPilotosService = tabelaPilotosService;
            TabelaEquipesService = tabelaEquipesService;
            GraficoCampeonatoPilotosService = graficoCampeonatoPilotosService;
            GraficoCampeonatoEquipesService = graficoCampeonatoEquipesService;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PilotosPosicoes));
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPosicoes()
        {
            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos()
        {
            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos()
        {
            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoPilotosPontos()
        {
            var pilotosGrafico = GraficoCampeonatoPilotosService.GetGraficoCampeonatoPilotos(TEMPORADA);

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoEquipesPontos()
        {
            var equipesGrafico = GraficoCampeonatoEquipesService.GetGraficoCampeonatoEquipes(TEMPORADA);

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
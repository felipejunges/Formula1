using Formula1.Data.Models;
using Formula1.Domain.Services;
using Formula1.Infra.Database.SqlServer;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            int? order = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA, order);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos()
        {
            int? order = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA, order);

            return View(campeonato);
        }

        [Route("Api/Piloto")]
        public List<PilotoTemporada> PilotosPontosApi()
        {
            var pilotos = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA, null).Pilotos;

            return pilotos;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos()
        {
            int? order = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(TEMPORADA, order);

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
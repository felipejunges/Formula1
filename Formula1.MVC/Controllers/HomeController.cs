using Formula1.Domain.Services;
using Formula1.Infra.Database.SqlServer;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const int TEMPORADA = 2020;

        private readonly TabelaPilotosService TabelaPilotosService;
        private readonly TabelaEquipesService TabelaEquipesService;
        private readonly PilotoTemporadaService PilotoTemporadaService;
        private readonly EquipeTemporadaService EquipeTemporadaService;
        private readonly GraficoCampeonatoPilotosService GraficoCampeonatoPilotosService;
        private readonly GraficoCampeonatoEquipesService GraficoCampeonatoEquipesService;

        public HomeController(F1Db db, TabelaPilotosService tabelaPilotosService, TabelaEquipesService tabelaEquipesService, PilotoTemporadaService pilotoTemporadaService, EquipeTemporadaService equipeTemporadaService, GraficoCampeonatoPilotosService graficoCampeonatoPilotosService, GraficoCampeonatoEquipesService graficoCampeonatoEquipesService)
        {
            TabelaPilotosService = tabelaPilotosService;
            TabelaEquipesService = tabelaEquipesService;
            PilotoTemporadaService = pilotoTemporadaService;
            EquipeTemporadaService = equipeTemporadaService;
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
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA, corridaOrder);

            ViewData["Temporada"] = TEMPORADA;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos()
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(TEMPORADA, corridaOrder);

            ViewData["Temporada"] = TEMPORADA;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos()
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(TEMPORADA, corridaOrder);

            ViewData["Temporada"] = TEMPORADA;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoPilotosPontos()
        {
            var pilotosGrafico = GraficoCampeonatoPilotosService.GetGraficoCampeonatoPilotos(TEMPORADA);

            ViewData["Temporada"] = TEMPORADA;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoEquipesPontos()
        {
            var equipesGrafico = GraficoCampeonatoEquipesService.GetGraficoCampeonatoEquipes(TEMPORADA);

            ViewData["Temporada"] = TEMPORADA;

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calcular(int? id)
        {
            if (id == null)
                return BadRequest("Temporada não informada.");

            this.PilotoTemporadaService.CalcularPilotosTemporada(id.Value);
            this.EquipeTemporadaService.CalcularEquipesTemporada(id.Value);

            return Ok($"Gerado cálculo da temporada {id}.");
        }
    }
}
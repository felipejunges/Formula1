using Formula1.Domain.Services;
using Formula1.Domain.Settings;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ParametrosSettings _settings;

        private readonly TabelaPilotosService TabelaPilotosService;
        private readonly TabelaEquipesService TabelaEquipesService;
        private readonly PilotoTemporadaService PilotoTemporadaService;
        private readonly EquipeTemporadaService EquipeTemporadaService;
        private readonly GraficoCampeonatoPilotosService GraficoCampeonatoPilotosService;
        private readonly GraficoCampeonatoEquipesService GraficoCampeonatoEquipesService;

        public HomeController(ParametrosSettings settings, TabelaPilotosService tabelaPilotosService, TabelaEquipesService tabelaEquipesService, PilotoTemporadaService pilotoTemporadaService, EquipeTemporadaService equipeTemporadaService, GraficoCampeonatoPilotosService graficoCampeonatoPilotosService, GraficoCampeonatoEquipesService graficoCampeonatoEquipesService)
        {
            _settings = settings;
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

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(_settings.TemporadaAtiva, corridaOrder, false);

            ViewData["Temporada"] = _settings.TemporadaAtiva;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos()
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(_settings.TemporadaAtiva, corridaOrder, true);

            ViewData["Temporada"] = _settings.TemporadaAtiva;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos()
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(_settings.TemporadaAtiva, corridaOrder);

            ViewData["Temporada"] = _settings.TemporadaAtiva;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoPilotosPontos()
        {
            var pilotosGrafico = GraficoCampeonatoPilotosService.GetGraficoCampeonatoPilotos(_settings.TemporadaAtiva);

            ViewData["Temporada"] = _settings.TemporadaAtiva;

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoEquipesPontos()
        {
            var equipesGrafico = GraficoCampeonatoEquipesService.GetGraficoCampeonatoEquipes(_settings.TemporadaAtiva);

            ViewData["Temporada"] = _settings.TemporadaAtiva;

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calcular()
        {
            this.PilotoTemporadaService.CalcularPilotosTemporada(_settings.TemporadaAtiva);
            this.EquipeTemporadaService.CalcularEquipesTemporada(_settings.TemporadaAtiva);

            return Ok($"Gerado cálculo da temporada {_settings.TemporadaAtiva}.");
        }
    }
}
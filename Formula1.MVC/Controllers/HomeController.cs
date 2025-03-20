using Formula1.Domain.Services;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TabelaPilotosService TabelaPilotosService;
        private readonly TabelaEquipesService TabelaEquipesService;
        private readonly PilotoTemporadaService PilotoTemporadaService;
        private readonly EquipeTemporadaService EquipeTemporadaService;
        
        public HomeController(TabelaPilotosService tabelaPilotosService, TabelaEquipesService tabelaEquipesService, PilotoTemporadaService pilotoTemporadaService, EquipeTemporadaService equipeTemporadaService)
        {
            TabelaPilotosService = tabelaPilotosService;
            TabelaEquipesService = tabelaEquipesService;
            PilotoTemporadaService = pilotoTemporadaService;
            EquipeTemporadaService = equipeTemporadaService;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PilotosPosicoes));
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPosicoes(int temporada)
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(temporada, corridaOrder, false);

            ViewData["Temporada"] = temporada;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos(int temporada)
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(temporada, corridaOrder, true);

            ViewData["Temporada"] = temporada;

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos(int temporada)
        {
            int? corridaOrder = !string.IsNullOrEmpty(Request.Query["o"]) ? Convert.ToInt32(Request.Query["o"]) : (int?)null;

            var campeonato = TabelaEquipesService.GetTabelaCampeonatoEquipes(temporada, corridaOrder);

            ViewData["Temporada"] = temporada;

            return View(campeonato);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Calcular(int temporada)
        {
            PilotoTemporadaService.CalcularPilotosTemporada(temporada);
            EquipeTemporadaService.CalcularEquipesTemporada(temporada);

            return Ok($"Gerado cálculo da temporada {temporada}.");
        }
    }
}
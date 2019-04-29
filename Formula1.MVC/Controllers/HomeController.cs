using Formula1.Domain.Services;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const int TEMPORADA = 2019;

        private readonly TemporadaService TemporadaService;

        public HomeController(TemporadaService temporadaService)
        {
            TemporadaService = temporadaService;
        }

        [ResponseCache(Duration = 60)]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PilotosPosicoes));
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPosicoes()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoPilotos(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult PilotosPontos()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoPilotos(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult EquipesPontos()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoEquipes(TEMPORADA);

            return View(campeonato);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoPilotosPontos()
        {
            var pilotosGrafico = TemporadaService.GetGraficoCampeonatoPilotos(TEMPORADA);

            return View(pilotosGrafico);
        }

        [ResponseCache(Duration = 60)]
        public IActionResult GraficoEquipesPontos()
        {
            var equipesGrafico = TemporadaService.GetGraficoCampeonatoEquipes(TEMPORADA);

            return View(equipesGrafico);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
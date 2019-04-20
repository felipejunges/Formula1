using Formula1.Domain.Services;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TemporadaService TemporadaService;

        public HomeController(TemporadaService temporadaService)
        {
            TemporadaService = temporadaService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(PilotosPosicoes));
        }

        public IActionResult PilotosPosicoes()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoPilotosPorPosicoes(2019);

            return View(campeonato);
        }

        public IActionResult PilotosPontos()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoPilotosPorPontos(2019);

            return View(campeonato);
        }

        public IActionResult EquipesPontos()
        {
            var campeonato = TemporadaService.GetTabelaCampeonatoEquipesPorPontos(2019);

            return View(campeonato);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
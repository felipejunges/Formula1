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
            var campeonato = TemporadaService.GetCampeonato(2019);

            return View(campeonato);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
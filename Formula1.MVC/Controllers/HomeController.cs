using Formula1.Data.Entities;
using Formula1.Domain.Services;
using Formula1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Formula1.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // TODO: injeção de dependência
            var temporadaService = new TemporadaService();

            var corridas = temporadaService.GetCorridas2019().ToList();

            List<Piloto> pilotos = new List<Piloto>();
            foreach (var corrida in corridas)
            {
                foreach (var resultado in corrida.Resultados)
                {
                    if (!pilotos.Contains(resultado.Piloto))
                        pilotos.Add(resultado.Piloto);
                }
            }

            var campeonato = new ResultadoCampeonatoModel(corridas, pilotos);

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
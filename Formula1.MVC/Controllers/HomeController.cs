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

            // TODO: essa regra deveria estar na service
            List<PilotoPontosModel> pilotos = new List<PilotoPontosModel>();
            foreach (var corrida in corridas)//.Sum(s => s.Resultados.GroupBy(g => g).Sum(ss => ss.Key.Pontos)))
            {
                foreach (var resultado in corrida.Resultados)
                {
                    var pilotoPontos = pilotos.Where(o => o.Piloto == resultado.Piloto).FirstOrDefault();

                    if (pilotoPontos == null)
                        pilotos.Add(new PilotoPontosModel(resultado.Piloto, resultado.Pontos));
                    else
                        pilotoPontos.Pontos += resultado.Pontos;
                }
            }

            pilotos.Sort((o, i) => i.Pontos.CompareTo(o.Pontos));

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
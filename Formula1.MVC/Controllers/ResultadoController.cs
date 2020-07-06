using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ResultadosService ResultadosService;

        public ResultadoController(ResultadosService resultadosService)
        {
            this.ResultadosService = resultadosService;
        }

        public IActionResult Index(int id)
        {
            var resultados = this.ResultadosService.ObterListaResultados(id);

            ViewData["CorridaId"] = id;

            return View(resultados);
        }

        public IActionResult Add(ResultadoInclusao resultadoInclusao)
        {
            this.ResultadosService.Incluir(resultadoInclusao);

            return RedirectToAction("Index", new { id = resultadoInclusao.CorridaId });
        }
    }
}
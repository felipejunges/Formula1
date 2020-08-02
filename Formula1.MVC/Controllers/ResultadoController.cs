using Formula1.Data.Models;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Formula1.MVC.Controllers
{
    public class ResultadoController : Controller
    {
        private const int TEMPORADA = 2020;

        private readonly PilotosService PilotosService;
        private readonly EquipesService EquipesService;
        private readonly ResultadosService ResultadosService;

        public ResultadoController(PilotosService pilotosService, EquipesService equipesService, ResultadosService resultadosService)
        {
            this.PilotosService = pilotosService;
            this.EquipesService = equipesService;
            this.ResultadosService = resultadosService;
        }

        public IActionResult Index(int corridaId)
        {
            var dados = new ResultadoInclusao() { Id = 0, CorridaId = corridaId };
            var resultados = this.ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoCorridaEdicao(dados, resultados);

            ViewData["PilotosLista"] = new SelectList(this.PilotosService.ObterPilotosTabela(TEMPORADA), "Id", "NomeGuerra", null);
            ViewData["EquipesLista"] = new SelectList(this.EquipesService.ObterEquipesTabela(TEMPORADA), "Id", "Nome", null);

            return View(edicao);
        }

        public IActionResult Edit(int corridaId, int id)
        {
            var resultado = this.ResultadosService.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            var dados = new ResultadoInclusao(resultado);
            var resultados = this.ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoCorridaEdicao(dados, resultados);

            ViewData["PilotosLista"] = new SelectList(this.PilotosService.ObterPilotosTabela(TEMPORADA), "Id", "NomeGuerra", null);
            ViewData["EquipesLista"] = new SelectList(this.EquipesService.ObterEquipesTabela(TEMPORADA), "Id", "Nome", null);

            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(ResultadoInclusao resultadoInclusao)
        {
            if (ModelState.IsValid)
            {
                if (resultadoInclusao.Id == 0)
                    this.ResultadosService.Incluir(resultadoInclusao);
                else
                    this.ResultadosService.Alterar(resultadoInclusao);
            }

            return RedirectToAction("Index", new { corridaId = resultadoInclusao.CorridaId });
        }

        public IActionResult Delete(int corridaId, int id)
        {
            var resultado = this.ResultadosService.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            this.ResultadosService.Excluir(resultado);

            return RedirectToAction("Index", new { corridaId });
        }
    }
}
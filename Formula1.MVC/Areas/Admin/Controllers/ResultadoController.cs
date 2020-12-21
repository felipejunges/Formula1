using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ResultadoController : Controller
    {
        private readonly CorridasService CorridasService;
        private readonly PilotosService PilotosService;
        private readonly EquipesService EquipesService;
        private readonly ResultadosService ResultadosService;

        public ResultadoController(CorridasService corridasService, PilotosService pilotosService, EquipesService equipesService, ResultadosService resultadosService)
        {
            this.CorridasService = corridasService;
            this.PilotosService = pilotosService;
            this.EquipesService = equipesService;
            this.ResultadosService = resultadosService;
        }

        public IActionResult Index(int corridaId)
        {
            var dados = new ResultadoDados() { Id = 0, CorridaId = corridaId };
            var resultados = this.ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoListaDados(dados, resultados);

            //
            SetarDadosViewData(corridaId);

            return View(edicao);
        }
        
        public IActionResult Edit(int corridaId, int id)
        {
            var resultado = this.ResultadosService.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            var dados = new ResultadoDados(resultado);
            var resultados = this.ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoListaDados(dados, resultados);

            //
            SetarDadosViewData(corridaId);

            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(ResultadoDados resultadoDados)
        {
            if (ModelState.IsValid)
            {
                if (resultadoDados.Id == 0)
                    this.ResultadosService.Incluir(resultadoDados);
                else
                    this.ResultadosService.Alterar(resultadoDados);

                return RedirectToAction("Index", new { corridaId = resultadoDados.CorridaId });
            }

            //
            var resultados = this.ResultadosService.ObterListaResultados(resultadoDados.CorridaId);
            var edicao = new ResultadoListaDados(resultadoDados, resultados);

            SetarDadosViewData(resultadoDados.CorridaId);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int corridaId, int id)
        {
            var resultado = this.ResultadosService.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            this.ResultadosService.Excluir(resultado);

            return RedirectToAction("Index", new { corridaId });
        }

        private void SetarDadosViewData(int corridaId)
        {
            var corrida = this.CorridasService.ObterPeloId(corridaId);

            ViewData["PilotosLista"] = new SelectList(this.PilotosService.ObterPilotosContrato(corrida.Temporada), "Id", "NomeGuerra", null);
            ViewData["EquipesLista"] = new SelectList(this.EquipesService.ObterEquipesContrato(corrida.Temporada), "Id", "Nome", null);
            ViewData["NomeGP"] = $"{corrida.NomeGrandePremio} - {corrida.Temporada}";
        }
    }
}
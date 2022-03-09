using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            CorridasService = corridasService;
            PilotosService = pilotosService;
            EquipesService = equipesService;
            ResultadosService = resultadosService;
        }

        public IActionResult Index(int corridaId)
        {
            var corrida = CorridasService.ObterPeloId(corridaId);

            if (corrida is null)
                return NotFound();

            var dados = new ResultadoDados(
                corridaId,
                corrida.CorridaClassificacao,
                PilotosService.ObterPilotosContrato(corrida.Temporada),
                EquipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoListaDados(
                dados,
                resultados,
                corrida);

            //
            return View(edicao);
        }

        public IActionResult Edit(int corridaId, int id)
        {
            var resultado = this.ResultadosService.ObterPeloId(id);

            if (resultado is null)
                return BadRequest();

            var corrida = CorridasService.ObterPeloId(corridaId);

            if (corrida == null)
                return BadRequest();

            var dados = new ResultadoDados(
                resultado,
                PilotosService.ObterPilotosContrato(corrida.Temporada),
                EquipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = this.ResultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoListaDados(
                dados,
                resultados,
                corrida);

            //
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
            var corrida = CorridasService.ObterPeloId(resultadoDados.CorridaId);

            if (corrida == null)
                return BadRequest();

            resultadoDados.AtualizarListas(
                PilotosService.ObterPilotosContrato(corrida.Temporada),
                EquipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = this.ResultadosService.ObterListaResultados(resultadoDados.CorridaId);

            var edicao = new ResultadoListaDados(
                resultadoDados,
                resultados,
                corrida);

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
    }
}
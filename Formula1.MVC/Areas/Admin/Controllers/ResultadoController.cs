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
        private readonly CorridasService _corridasService;
        private readonly PilotosService _pilotosService;
        private readonly EquipesService _equipesService;
        private readonly ResultadosService _resultadosService;

        public ResultadoController(CorridasService corridasService, PilotosService pilotosService, EquipesService equipesService, ResultadosService resultadosService)
        {
            _corridasService = corridasService;
            _pilotosService = pilotosService;
            _equipesService = equipesService;
            _resultadosService = resultadosService;
        }

        public IActionResult Index(int corridaId)
        {
            var corrida = _corridasService.ObterPeloId(corridaId);

            if (corrida is null)
                return NotFound();

            var dados = new ResultadoDados(
                corridaId,
                corrida.CorridaClassificacao,
                _pilotosService.ObterPilotosContrato(corrida.Temporada),
                _equipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(corridaId);

            var edicao = new ResultadoListaDados(
                dados,
                resultados,
                corrida);

            //
            return View(edicao);
        }

        public IActionResult Edit(int corridaId, int id)
        {
            var resultado = _resultadosService.ObterPeloId(id);

            if (resultado is null)
                return BadRequest();

            var corrida = _corridasService.ObterPeloId(corridaId);

            if (corrida == null)
                return BadRequest();

            var dados = new ResultadoDados(
                resultado,
                _pilotosService.ObterPilotosContrato(corrida.Temporada),
                _equipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(corridaId);

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
                    _resultadosService.Incluir(resultadoDados);
                else
                    _resultadosService.Alterar(resultadoDados);

                return RedirectToAction("Index", new { corridaId = resultadoDados.CorridaId });
            }

            //
            var corrida = _corridasService.ObterPeloId(resultadoDados.CorridaId);

            if (corrida == null)
                return BadRequest();

            resultadoDados.AtualizarListas(
                _pilotosService.ObterPilotosContrato(corrida.Temporada),
                _equipesService.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(resultadoDados.CorridaId);

            var edicao = new ResultadoListaDados(
                resultadoDados,
                resultados,
                corrida);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int corridaId, int id)
        {
            var resultado = _resultadosService.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            _resultadosService.Excluir(resultado);

            return RedirectToAction("Index", new { corridaId });
        }
    }
}
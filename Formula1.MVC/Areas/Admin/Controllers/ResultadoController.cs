using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ResultadoController : Controller
    {
        private readonly ICorridasRepository _corridasRepository;
        private readonly IPilotosRepository _pilotosRepository;
        private readonly IEquipesRepository _equipesRepository;
        private readonly IResultadosRepository _resultadosRepository;
        private readonly IContratosRepository _contratosRepository;
        private readonly ResultadosService _resultadosService;

        public ResultadoController(ICorridasRepository corridasRepository, IPilotosRepository pilotosRepository, IEquipesRepository equipesRepository, IResultadosRepository resultadosRepository, IContratosRepository contratosRepository, ResultadosService resultadosService)
        {
            _corridasRepository = corridasRepository;
            _pilotosRepository = pilotosRepository;
            _equipesRepository = equipesRepository;
            _resultadosRepository = resultadosRepository;
            _contratosRepository = contratosRepository;
            _resultadosService = resultadosService;
        }

        public IActionResult Index(int corridaId)
        {
            var corrida = _corridasRepository.ObterPeloId(corridaId);

            if (corrida is null)
                return NotFound();

            var dados = new ResultadoDados(
                corridaId,
                corrida.CorridaClassificacao,
                _pilotosRepository.ObterPilotosContrato(corrida.Temporada),
                _equipesRepository.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(corridaId);

            var equipesPilotos = _contratosRepository.ObterResultadoEquipesPilotos(corrida.Temporada);

            var edicao = new ResultadoListaDados(
                dados,
                resultados,
                equipesPilotos,
                corrida);

            //
            return View(edicao);
        }

        public IActionResult Edit(int corridaId, int id)
        {
            var resultado = _resultadosRepository.ObterPeloId(id);

            if (resultado is null)
                return BadRequest();

            var corrida = _corridasRepository.ObterPeloId(corridaId);

            if (corrida == null)
                return BadRequest();

            var dados = new ResultadoDados(
                resultado,
                _pilotosRepository.ObterPilotosContrato(corrida.Temporada),
                _equipesRepository.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(corridaId);

            var equipesPilotos = _contratosRepository.ObterResultadoEquipesPilotos(corrida.Temporada);

            var edicao = new ResultadoListaDados(
                dados,
                resultados,
                equipesPilotos,
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
                    _resultadosRepository.Incluir(resultadoDados);
                else
                    _resultadosRepository.Alterar(resultadoDados);

                return RedirectToAction("Index", new { corridaId = resultadoDados.CorridaId });
            }

            //
            var corrida = _corridasRepository.ObterPeloId(resultadoDados.CorridaId);

            if (corrida == null)
                return BadRequest();

            resultadoDados.AtualizarListas(
                _pilotosRepository.ObterPilotosContrato(corrida.Temporada),
                _equipesRepository.ObterEquipesContrato(corrida.Temporada));

            var resultados = _resultadosService.ObterListaResultados(resultadoDados.CorridaId);

            var equipesPilotos = _contratosRepository.ObterResultadoEquipesPilotos(corrida.Temporada);

            var edicao = new ResultadoListaDados(
                resultadoDados,
                resultados,
                equipesPilotos,
                corrida);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int corridaId, int id)
        {
            var resultado = _resultadosRepository.ObterPeloId(id);

            if (resultado == null)
                return NotFound();

            _resultadosRepository.Excluir(resultado);

            return RedirectToAction("Index", new { corridaId });
        }
    }
}
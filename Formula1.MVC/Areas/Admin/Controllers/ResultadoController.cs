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
            return MontarViewCorrida(corridaId, false);
        }

        public IActionResult Sprint(int corridaId)
        {
            return MontarViewCorrida(corridaId, true);
        }

        public IActionResult MontarViewCorrida(int corridaId, bool corridaSprint)
        {
            var corrida = _corridasRepository.ObterPeloId(corridaId);

            if (corrida is null)
                return NotFound();

            var pilotos = _pilotosRepository.ObterPilotosContrato(corrida.Temporada);
            var equipes = _equipesRepository.ObterEquipesContrato(corrida.Temporada);

            var resultados = _resultadosService.ObterListaResultados(corrida, corridaSprint);

            var equipesPilotos = _contratosRepository.ObterResultadoEquipesPilotos(corrida.Temporada);

            var edicao = new ResultadoListaDados(
                corridaId,
                corrida.Temporada,
                corridaSprint,
                resultados,
                pilotos,
                equipes,
                equipesPilotos,
                corrida);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(ResultadoListaDados resultadoListaDados)
        {
            if (ModelState.IsValid)
            {
                _resultadosService.PersistirResultadosCorrida(resultadoListaDados);

                var viewToRedirect = resultadoListaDados.CorridaSprint ? nameof(Sprint) : nameof(Index);
                
                return RedirectToAction(viewToRedirect, new { corridaId = resultadoListaDados.CorridaId });
            }

            //
            var corrida = _corridasRepository.ObterPeloId(resultadoListaDados.CorridaId);

            if (corrida == null)
                return BadRequest();

            var pilotos = _pilotosRepository.ObterPilotosContrato(corrida.Temporada);
            var equipes = _equipesRepository.ObterEquipesContrato(corrida.Temporada);
            var equipesPilotos = _contratosRepository.ObterResultadoEquipesPilotos(corrida.Temporada);
            
            resultadoListaDados.AtualizarListas(
                pilotos,
                equipes,
                equipesPilotos);

            return View(nameof(Index), resultadoListaDados);
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
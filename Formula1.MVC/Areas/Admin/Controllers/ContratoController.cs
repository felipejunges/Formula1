using Formula1.Data.Models.Admin.Contratos;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ContratoController : Controller
    {
        private readonly ContratosService _contratosService;
        private readonly PilotosService _pilotosService;
        private readonly EquipesService _equipesService;

        public ContratoController(ContratosService contratosService, PilotosService pilotosService, EquipesService equipesService)
        {
            _contratosService = contratosService;
            _pilotosService = pilotosService;
            _equipesService = equipesService;
        }

        public IActionResult Index(int temporada)
        {
            var dados = new ContratoDados(
                temporada,
                _pilotosService.ObterPilotosContrato(temporada),
                _equipesService.ObterEquipesContrato(temporada));

            var contratosLista = _contratosService.ObterContratosLista(temporada);

            var edicao = new ContratoListaDados(dados, contratosLista);

            //
            return View(edicao);
        }

        public IActionResult Edit(int id, int temporada)
        {
            var contrato = _contratosService.ObterPeloId(id);

            if (contrato == null)
                return NotFound();

            var dados = new ContratoDados(
                contrato,
                _pilotosService.ObterPilotosContrato(contrato.Temporada),
                _equipesService.ObterEquipesContrato(contrato.Temporada));

            var contratosLista = _contratosService.ObterContratosLista(temporada);

            var edicao = new ContratoListaDados(dados, contratosLista);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(ContratoDados contratoDados)
        {
            if (ModelState.IsValid)
            {
                if (contratoDados.Id == 0)
                    _contratosService.Incluir(contratoDados);
                else
                    _contratosService.Alterar(contratoDados);

                return RedirectToAction(nameof(Index));
            }

            //
            contratoDados.AtualizarListas(
                _pilotosService.ObterPilotosContrato(contratoDados.Temporada),
                _equipesService.ObterEquipesContrato(contratoDados.Temporada));

            var contratosLista = _contratosService.ObterContratosLista(contratoDados.Temporada);

            var edicao = new ContratoListaDados(contratoDados, contratosLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var contrato = _contratosService.ObterPeloId(id);

            if (contrato == null)
                return NotFound();

            _contratosService.Excluir(contrato);

            return RedirectToAction(nameof(Index));
        }
    }
}
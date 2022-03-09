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
            var dados = new ContratoDados() { Id = 0, Temporada = temporada };
            var contratosLista = _contratosService.ObterContratosLista(temporada);

            var edicao = new ContratoListaDados(dados, contratosLista);

            //
            SetarDadosViewData(temporada);

            return View(edicao);
        }

        public IActionResult Edit(int id, int temporada)
        {
            var contrato = _contratosService.ObterPeloId(id);

            if (contrato == null)
                return NotFound();

            var dados = new ContratoDados(contrato);
            var contratosLista = _contratosService.ObterContratosLista(temporada);

            var edicao = new ContratoListaDados(dados, contratosLista);

            //
            SetarDadosViewData(temporada);

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
            SetarDadosViewData(contratoDados.Temporada); // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

            var contratosLista = _contratosService.ObterContratosLista(contratoDados.Temporada); // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

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

        private void SetarDadosViewData(int temporada)
        {
            ViewData["Temporada"] = temporada;

            ViewData["PilotosLista"] = new SelectList(_pilotosService.ObterPilotosAtivos(), "Id", "NomeGuerra", null);
            ViewData["EquipesLista"] = new SelectList(_equipesService.ObterEquipesAtivas(), "Id", "Nome", null);
        }
    }
}
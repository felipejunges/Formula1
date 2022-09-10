using Formula1.Data.Models.Admin.Contratos;
using Formula1.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ContratoController : Controller
    {
        private readonly IContratosRepository _contratosRepository;
        private readonly IPilotosRepository _pilotosRepository;
        private readonly IEquipesRepository _equipesRepository;

        public ContratoController(IContratosRepository contratosRepository, IPilotosRepository pilotosRepository, IEquipesRepository equipesRepository)
        {
            _contratosRepository = contratosRepository;
            _pilotosRepository = pilotosRepository;
            _equipesRepository = equipesRepository;
        }

        public IActionResult Index(int temporada)
        {
            var dados = new ContratoDados(
                temporada,
                _pilotosRepository.ObterPilotosAtivos(),
                _equipesRepository.ObterEquipesAtivas());

            var contratosLista = _contratosRepository.ObterContratosLista(temporada);

            var edicao = new ContratoListaDados(dados, contratosLista);

            //
            return View(edicao);
        }

        public IActionResult Edit(int id, int temporada)
        {
            var contrato = _contratosRepository.ObterPeloId(id);

            if (contrato == null)
                return NotFound();

            var dados = new ContratoDados(
                contrato,
                _pilotosRepository.ObterPilotosAtivos(),
                _equipesRepository.ObterEquipesAtivas());

            var contratosLista = _contratosRepository.ObterContratosLista(temporada);

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
                    _contratosRepository.Incluir(contratoDados);
                else
                    _contratosRepository.Alterar(contratoDados);

                return RedirectToAction(nameof(Index));
            }

            //
            contratoDados.AtualizarListas(
                _pilotosRepository.ObterPilotosAtivos(),
                _equipesRepository.ObterEquipesAtivas());

            var contratosLista = _contratosRepository.ObterContratosLista(contratoDados.Temporada);

            var edicao = new ContratoListaDados(contratoDados, contratosLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var contrato = _contratosRepository.ObterPeloId(id);

            if (contrato == null)
                return NotFound();

            _contratosRepository.Excluir(contrato);

            return RedirectToAction(nameof(Index));
        }
    }
}
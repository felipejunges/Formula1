using Formula1.Data.Models.Admin.Pilotos;
using Formula1.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PilotoController : Controller
    {
        private readonly IPilotosRepository _pilotosRepository;

        public PilotoController(IPilotosRepository pilotosRepository)
        {
            _pilotosRepository = pilotosRepository;
        }

        public IActionResult Index()
        {
            var dados = PilotoDados.Novo();
            var pilotos = _pilotosRepository.ObterPilotosLista();

            var edicao = new PilotoListaDados(dados, pilotos);

            return View(edicao);
        }

        public IActionResult Edit(int id)
        {
            var piloto = _pilotosRepository.ObterPeloId(id);

            if (piloto == null)
                return NotFound();

            var dados = new PilotoDados(piloto);
            var pilotosLista = _pilotosRepository.ObterPilotosLista();

            var edicao = new PilotoListaDados(dados, pilotosLista);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(PilotoDados pilotoDados)
        {
            if (ModelState.IsValid)
            {
                if (pilotoDados.Id == 0)
                    _pilotosRepository.Incluir(pilotoDados);
                else
                    _pilotosRepository.Alterar(pilotoDados);

                return RedirectToAction("Index");
            }

            //
            var pilotosLista = _pilotosRepository.ObterPilotosLista();

            var edicao = new PilotoListaDados(pilotoDados, pilotosLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var piloto = _pilotosRepository.ObterPeloId(id);

            if (piloto == null)
                return NotFound();

            _pilotosRepository.Excluir(piloto);

            return RedirectToAction("Index");
        }
    }
}
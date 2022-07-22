using Formula1.Data.Models.Admin.Corridas;
using Formula1.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CorridaController : Controller
    {
        private readonly ICorridasRepository _corridasRepository;

        public CorridaController(ICorridasRepository corridasRepository)
        {
            _corridasRepository = corridasRepository;
        }

        public IActionResult Index(int temporada)
        {
            var dados = CorridaDados.Novo(temporada);
            var corridasLista = _corridasRepository.GetCorridasLista(temporada);

            var edicao = new CorridaListaDados(dados, corridasLista);

            ViewData["Temporada"] = temporada;

            return View(edicao);
        }

        public IActionResult Edit(int id, int temporada)
        {
            var corrida = _corridasRepository.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            var dados = new CorridaDados(corrida);
            var corridasLista = _corridasRepository.GetCorridasLista(temporada);

            var edicao = new CorridaListaDados(dados, corridasLista);

            //
            ViewData["Temporada"] = temporada;

            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(CorridaDados corridaDados, int temporada)
        {
            if (ModelState.IsValid)
            {
                if (corridaDados.Id == 0)
                    _corridasRepository.Incluir(corridaDados);
                else
                    _corridasRepository.Alterar(corridaDados);

                return RedirectToAction("Index");
            }

            //
            var corridasLista = _corridasRepository.GetCorridasLista(temporada); // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

            var edicao = new CorridaListaDados(corridaDados, corridasLista);

            ViewData["Temporada"] = temporada; // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var corrida = _corridasRepository.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            _corridasRepository.Excluir(corrida);

            return RedirectToAction("Index");
        }
    }
}
using Formula1.Data.Models.Admin.Corridas;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CorridaController : Controller
    {
        private const int TEMPORADA = 2020; // TODO: transformar em uma config vinda do banco

        private readonly CorridasService _corridasService;

        public CorridaController(CorridasService corridasService)
        {
            _corridasService = corridasService;
        }

        public IActionResult Index()
        {
            var dados = new CorridaDados() { Id = 0, Temporada = TEMPORADA, Inclusao = true };
            var corridasLista = _corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(dados, corridasLista);

            ViewData["Temporada"] = TEMPORADA;

            return View(edicao);
        }

        public IActionResult Edit(int id)
        {
            var corrida = _corridasService.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            var dados = new CorridaDados(corrida);
            var corridasLista = _corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(dados, corridasLista);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(CorridaDados corridaDados)
        {
            if (ModelState.IsValid)
            {
                if (corridaDados.Inclusao)
                    _corridasService.Incluir(corridaDados);
                else
                    _corridasService.Alterar(corridaDados);

                return RedirectToAction("Index");
            }

            //
            var corridasLista = _corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(corridaDados, corridasLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var corrida = _corridasService.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            _corridasService.Excluir(corrida);

            return RedirectToAction("Index");
        }
    }
}
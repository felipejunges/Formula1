using Formula1.Data.Models.Admin;
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
            var dados = new CorridaDados() { Id = 0, Temporada = TEMPORADA };
            var corridasLista = _corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(dados, corridasLista);

            ViewData["Temporada"] = TEMPORADA;

            return View(edicao);
        }

        public IActionResult Edit(int corridaId, int id)
        {
            var corrida = this._corridasService.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            var dados = new CorridaDados(corrida);
            var corridasLista = this._corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(dados, corridasLista);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(CorridaDados corridaDados)
        {
            if (ModelState.IsValid)
            {
                if (corridaDados.Id == 0)
                    this._corridasService.Incluir(corridaDados);
                else
                    this._corridasService.Alterar(corridaDados);

                return RedirectToAction("Index");
            }

            //
            var corridasLista = this._corridasService.GetCorridasLista(TEMPORADA);

            var edicao = new CorridaListaDados(corridaDados, corridasLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int corridaId, int id)
        {
            var corrida = this._corridasService.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            this._corridasService.Excluir(corrida);

            return RedirectToAction("Index", new { corridaId });
        }
    }
}
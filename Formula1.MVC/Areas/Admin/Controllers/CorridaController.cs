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
        private readonly CorridasService _corridasService;

        public CorridaController(CorridasService corridasService)
        {
            _corridasService = corridasService;
        }

        public IActionResult Index(int temporada)
        {
            var dados = CorridaDados.Novo(temporada);
            var corridasLista = _corridasService.GetCorridasLista(temporada);

            var edicao = new CorridaListaDados(dados, corridasLista);

            ViewData["Temporada"] = temporada;

            return View(edicao);
        }

        public IActionResult Edit(int id, int temporada)
        {
            var corrida = _corridasService.ObterPeloId(id);

            if (corrida == null)
                return NotFound();

            var dados = new CorridaDados(corrida);
            var corridasLista = _corridasService.GetCorridasLista(temporada);

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
                    _corridasService.Incluir(corridaDados);
                else
                    _corridasService.Alterar(corridaDados);

                return RedirectToAction("Index");
            }

            //
            var corridasLista = _corridasService.GetCorridasLista(temporada); // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

            var edicao = new CorridaListaDados(corridaDados, corridasLista);

            ViewData["Temporada"] = temporada; // TODO: analisar se nao é melhor receber no método mesmo o "temporada"

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
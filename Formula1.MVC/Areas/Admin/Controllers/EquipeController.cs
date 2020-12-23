using Formula1.Data.Models.Admin.Equipes;
using Formula1.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class EquipeController : Controller
    {
        private readonly EquipesService _equipesService;

        public EquipeController(EquipesService equipesService)
        {
            _equipesService = equipesService;
        }

        public IActionResult Index()
        {
            var dados = new EquipeDados() { Id = 0 };
            var equipes = _equipesService.ObterEquipesLista();

            var edicao = new EquipeListaDados(dados, equipes);

            return View(edicao);
        }

        public IActionResult Edit(int id)
        {
            var equipe = _equipesService.ObterPeloId(id);

            if (equipe == null)
                return NotFound();

            var dados = new EquipeDados(equipe);
            var equipesLista = _equipesService.ObterEquipesLista();

            var edicao = new EquipeListaDados(dados, equipesLista);

            //
            return View(nameof(Index), edicao);
        }

        [HttpPost]
        public IActionResult Save(EquipeDados equipeDados)
        {
            if (ModelState.IsValid)
            {
                if (equipeDados.Id == 0)
                    _equipesService.Incluir(equipeDados);
                else
                    _equipesService.Alterar(equipeDados);

                return RedirectToAction(nameof(Index));
            }

            //
            var equipesLista = _equipesService.ObterEquipesLista();

            var edicao = new EquipeListaDados(equipeDados, equipesLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var equipe = _equipesService.ObterPeloId(id);

            if (equipe == null)
                return NotFound();

            _equipesService.Excluir(equipe);

            return RedirectToAction(nameof(Index));
        }
    }
}
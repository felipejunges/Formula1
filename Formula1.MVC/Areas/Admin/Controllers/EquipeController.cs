using Formula1.Data.Models.Admin.Equipes;
using Formula1.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class EquipeController : Controller
    {
        private readonly IEquipesRepository _equipesRepository;

        public EquipeController(IEquipesRepository equipesRepository)
        {
            _equipesRepository = equipesRepository;
        }

        public IActionResult Index()
        {
            var dados = EquipeDados.Novo();
            var equipes = _equipesRepository.ObterEquipesLista();

            var edicao = new EquipeListaDados(dados, equipes);

            return View(edicao);
        }

        public IActionResult Edit(int id)
        {
            var equipe = _equipesRepository.ObterPeloId(id);

            if (equipe == null)
                return NotFound();

            var dados = new EquipeDados(equipe);
            var equipesLista = _equipesRepository.ObterEquipesLista();

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
                    _equipesRepository.Incluir(equipeDados);
                else
                    _equipesRepository.Alterar(equipeDados);

                return RedirectToAction(nameof(Index));
            }

            //
            var equipesLista = _equipesRepository.ObterEquipesLista();

            var edicao = new EquipeListaDados(equipeDados, equipesLista);

            return View(nameof(Index), edicao);
        }

        public IActionResult Delete(int id)
        {
            var equipe = _equipesRepository.ObterPeloId(id);

            if (equipe == null)
                return NotFound();

            _equipesRepository.Excluir(equipe);

            return RedirectToAction(nameof(Index));
        }
    }
}
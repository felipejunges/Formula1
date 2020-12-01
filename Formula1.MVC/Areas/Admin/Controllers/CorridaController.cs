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
            var corridasLista = _corridasService.GetCorridasLista(TEMPORADA);

            return View(corridasLista);
        }
    }
}
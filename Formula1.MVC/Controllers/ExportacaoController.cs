using Formula1.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Formula1.MVC.Controllers
{
    public class ExportacaoController : Controller
    {
        private readonly ExportacaoService _exportacaoService;

        public ExportacaoController(ExportacaoService exportacaoService)
        {
            _exportacaoService = exportacaoService;
        }

        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> Index()
        {
            var exportacao = await _exportacaoService.ObterDadosExportacao();
            var json = JsonConvert.SerializeObject(exportacao);

            return Content(json);
        }
    }
}
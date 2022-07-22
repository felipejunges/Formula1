using Formula1.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Formula1.MVC.Controllers
{
    [Authorize]
    public class ImportacaoController : Controller
    {
        private readonly IImportacaoService _importacaoService;

        public ImportacaoController(IImportacaoService importacaoService)
        {
            _importacaoService = importacaoService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Host.Host.Contains("somee")) // TODO: validar com o parâmetro da Api
            {
                return BadRequest("Não deve ser aplicada importação da própria API!");
            }

            try
            {
                await _importacaoService.ImportarDados();

                return Ok("Importação OK!");
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException is not null)
                    message += $" - {ex.InnerException.Message}";

                return BadRequest($"Erro na importação: {message}");
            }
        }
    }
}
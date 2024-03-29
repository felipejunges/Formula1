using Formula1.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Formula1.MVC.Controllers
{
    public class ExportacaoController : Controller
    {
        private readonly IExportacaoRepository _exportacaoRepository;

        public ExportacaoController(IExportacaoRepository exportacaoRepository)
        {
            _exportacaoRepository = exportacaoRepository;
        }

        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> Index()
        {
            var exportacao = await _exportacaoRepository.ObterDadosExportacao();

            var json = JsonConvert.SerializeObject(
                exportacao,
                new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() } });

            return Ok(json);
        }
    }
}
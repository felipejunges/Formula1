using Formula1.Domain.Interfaces.ApiServices;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Formula1.Domain.Services
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly IF1ApiService _f1ApiService;
        private readonly IImportacaoRepository _importacaoRepository;

        public ImportacaoService(IF1ApiService f1ApiService, IImportacaoRepository importacaoRepository)
        {
            _f1ApiService = f1ApiService;
            _importacaoRepository = importacaoRepository;
        }

        public async Task ImportarDados()
        {
            var dadosExportacao = await _f1ApiService.ObterDadosExportacao();

            if (dadosExportacao is null)
                return;

            await _importacaoRepository.ImportarDados(dadosExportacao);
        }
    }
}
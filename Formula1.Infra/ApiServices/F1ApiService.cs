using Formula1.Data.Models.Exportacoes;
using Formula1.Domain.Interfaces.ApiServices;
using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Formula1.Infra.ApiServices
{
    public class F1ApiService : IF1ApiService
    {
        private readonly HttpClient _httpClient;

        public F1ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Exportacao> ObterDadosExportacao()
        {
            var response = await _httpClient.GetAsync("2025/Exportacao"); // TODO: melhorar essa questão do ano (ser em apenas algumas rotas?)

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync(), null, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();

            var retorno = JsonConvert.DeserializeObject<Exportacao>(
                content,
                new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() });

            return retorno!;
        }
    }
}
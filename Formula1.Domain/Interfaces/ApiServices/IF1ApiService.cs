using Formula1.Data.Models.Exportacoes;
using System.Threading.Tasks;

namespace Formula1.Domain.Interfaces.ApiServices
{
    public interface IF1ApiService
    {
        Task<Exportacao> ObterDadosExportacao();
    }
}
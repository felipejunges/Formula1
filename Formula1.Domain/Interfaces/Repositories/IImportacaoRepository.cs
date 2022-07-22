using Formula1.Data.Models.Exportacoes;
using System.Threading.Tasks;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IImportacaoRepository
    {
        Task ImportarDados(Exportacao dadosExportacao);
    }
}
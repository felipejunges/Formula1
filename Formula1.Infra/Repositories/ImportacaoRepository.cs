using Formula1.Data.Models.Exportacoes;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1.Infra.Repositories
{
    public class ImportacaoRepository : IImportacaoRepository
    {
        private readonly F1Db Db;

        public ImportacaoRepository(F1Db db)
        {
            Db = db;
        }

        public async Task ImportarDados(Exportacao dadosExportacao)
        {
            Db.Pilotos.RemoveRange(Db.Pilotos);
            Db.Equipes.RemoveRange(Db.Equipes);
            Db.Contratos.RemoveRange(Db.Contratos);
            Db.Corridas.RemoveRange(Db.Corridas);
            Db.Resultados.RemoveRange(Db.Resultados);
            Db.Punicoes.RemoveRange(Db.Punicoes);
            Db.PilotosTemporada.RemoveRange(Db.PilotosTemporada);
            Db.EquipesTemporada.RemoveRange(Db.EquipesTemporada);

            await Db.Pilotos.AddRangeAsync(dadosExportacao.Pilotos.Select(p => p.MapPiloto()).ToList());
            await Db.Equipes.AddRangeAsync(dadosExportacao.Equipes.Select(p => p.MapEquipe()).ToList());
            await Db.Contratos.AddRangeAsync(dadosExportacao.Contratos.Select(p => p.MapContrato()).ToList());
            await Db.Corridas.AddRangeAsync(dadosExportacao.Corridas.Select(p => p.MapCorrida()).ToList());
            await Db.Resultados.AddRangeAsync(dadosExportacao.Resultados.Select(p => p.MapResultado()).ToList());
            await Db.Punicoes.AddRangeAsync(dadosExportacao.Punicoes.Select(p => p.MapPunicao()).ToList());
            await Db.PilotosTemporada.AddRangeAsync(dadosExportacao.PilotosTemporadas.Select(p => p.MapPilotoTemporada()).ToList());
            await Db.EquipesTemporada.AddRangeAsync(dadosExportacao.EquipesTemporadas.Select(p => p.MapEquipeTemporada()).ToList());

            await Db.SaveChangesAsync();

            // TODO: resetar as sequences
        }
    }
}
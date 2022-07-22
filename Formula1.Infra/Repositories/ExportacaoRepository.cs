using Formula1.Data.Models.Exportacoes;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1.Infra.Repositories
{
    public class ExportacaoRepository : IExportacaoRepository
    {
        private readonly F1Db Db;

        public ExportacaoRepository(F1Db db)
        {
            Db = db;
        }

        public async Task<Exportacao> ObterDadosExportacao()
        {
            var pilotos = await Db.Pilotos.AsNoTracking().ToListAsync();
            var equipes = await Db.Equipes.AsNoTracking().ToListAsync();
            var contratos = await Db.Contratos.AsNoTracking().ToListAsync();
            var corridas = await Db.Corridas.AsNoTracking().ToListAsync();
            var resultados = await Db.Resultados.AsNoTracking().ToListAsync();
            var punicoes = await Db.Punicoes.AsNoTracking().ToListAsync();
            var pilotosTemporadas = await Db.PilotosTemporada.Include(p => p.Piloto).AsNoTracking().ToListAsync();
            var equipesTemporadas = await Db.EquipesTemporada.Include(e => e.Equipe).AsNoTracking().ToListAsync();

            return new Exportacao(
                pilotos.Select(p => new PilotoExportacao(p)).ToList(),
                equipes.Select(e => new EquipeExportacao(e)).ToList(),
                contratos.Select(c => new ContratoExportacao(c)).ToList(),
                corridas.Select(c => new CorridaExportacao(c)).ToList(),
                resultados.Select(r => new ResultadoExportacao(r)).ToList(),
                punicoes.Select(p => new PunicaoExportacao(p)).ToList(),
                pilotosTemporadas.Select(p => new PilotoTemporadaExportacao(p)).ToList(),
                equipesTemporadas.Select(e => new EquipeTemporadaExportacao(e)).ToList());
        }
    }
}
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        //private readonly F1Db Db;
        private readonly CorridasService CorridasService;
        private readonly PilotosService PilotosService;

        //public TemporadaService(F1Db db, CorridasService corridasService)
        public TemporadaService(CorridasService corridasService)
        {
            //Db = db;
            CorridasService = corridasService;
        }

        public TabelaCampeonatoPilotosPosicoesModel GetTabelaCampeonatoPilotosPorPosicoes(int temporada)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.GetPilotosTabela(temporada);

            var pilotosResultados = CorridasService.GetPilotosResultadosPorPosicoes(temporada);

            return new TabelaCampeonatoPilotosPosicoesModel(corridas, pilotosResultados);
        }

        public TabelaCampeonatoPilotosPontosModel GetTabelaCampeonatoPilotosPorPontos(int temporada)
        {
            var corridas = CorridasService.GetCorridas(temporada);

            var pilotosResultados = CorridasService.GetPilotosResultadosPorPontos(temporada);

            return new TabelaCampeonatoPilotosPontosModel(corridas, pilotosResultados);
        }

        public TabelaCampeonatoEquipesPontosModel GetTabelaCampeonatoEquipesPorPontos(int temporada)
        {
            var corridas = CorridasService.GetCorridas(temporada);

            var equipesResultados = CorridasService.GetEquipesResultadosPorPontos(temporada);

            return new TabelaCampeonatoEquipesPontosModel(corridas, equipesResultados);
        }
    }
}
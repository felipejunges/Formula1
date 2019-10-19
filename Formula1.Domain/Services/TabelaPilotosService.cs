using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaPilotosService
    {
        private readonly CorridasService CorridasService;
        private readonly PilotosService PilotosService;
        private readonly ResultadosService ResultadosService;

        public TabelaPilotosService(CorridasService corridasService, PilotosService pilotosService, ResultadosService resultadosService)
        {
            CorridasService = corridasService;
            PilotosService = pilotosService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoPilotos GetTabelaCampeonatoPilotos(int temporada, int? order)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.GetPilotosTabela(temporada);
            var resultados = ResultadosService.GetResultadosPilotosTemporada(temporada);
            
            PreencherResultadosPilotosCorridas(corridas, pilotos, resultados);

            MarcarPilotosDisputamCampeonato(corridas, pilotos);

            if (order == null)
                pilotos.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));
            else
                pilotos.Sort((o, i) => o.Resultados[order.Value - 1].PosicaoChegada.CompareTo(i.Resultados[order.Value - 1].PosicaoChegada));

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }

        private void PreencherResultadosPilotosCorridas(List<CorridaTemporada> corridas, List<PilotoTemporada> pilotos, List<ResultadoTemporada> resultados)
        {
            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }

        private void MarcarPilotosDisputamCampeonato(List<CorridaTemporada> corridas, List<PilotoTemporada> pilotos)
        {
            int corridasRestantes = corridas.Where(o => o.Resultados.Count() == 0).Count();
            int pontosRestantes = corridasRestantes * ModelBuilderTemporada2019.PONTOS_MAXIMOS_CORRIDA_PILOTO;

            int pontosLider = pilotos.Select(o => o.PontosTemporada).OrderByDescending(o => o).First();
            pilotos.ForEach(f => f.DisputaCampeonato = f.PontosTemporada + pontosRestantes >= pontosLider);
        }
    }
}
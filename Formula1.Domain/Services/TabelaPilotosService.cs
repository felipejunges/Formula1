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
            
            if (order == null)
                pilotos.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));
            else
                pilotos.Sort((o, i) => o.Resultados[order.Value - 1].PosicaoChegada.CompareTo(i.Resultados[order.Value - 1].PosicaoChegada));

            var pontosRestantes = CalcularPontosRestantes(corridas);
            MarcarPilotosPosicaoMaxima(pilotos, pontosRestantes);

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }

        private void PreencherResultadosPilotosCorridas(List<CorridaTemporada> corridas, List<PilotoTemporada> pilotos, List<ResultadoTemporada> resultados)
        {
            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }

        private void MarcarPilotosPosicaoMaxima(List<PilotoTemporada> pilotos, int pontosRestantes)
        {
            pilotos.ForEach(f =>
                    f.PosicaoMaxima = pilotos.IndexOf(pilotos.Where(w => w.PontosTemporada <= f.PontosTemporada + pontosRestantes).OrderByDescending(o => o.PontosTemporada).FirstOrDefault()) + 1
                );
        }

        private int CalcularPontosRestantes(List<CorridaTemporada> corridas)
        {
            int corridasRestantes = corridas.Where(o => o.Resultados.Count() == 0).Count();
            int pontosRestantes = corridasRestantes * ModelBuilderTemporada2019.PONTOS_MAXIMOS_CORRIDA_PILOTO;

            return pontosRestantes;
        }
    }
}
using Formula1.Data.Models;
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

        public TabelaCampeonatoPilotos GetTabelaCampeonatoPilotos(int temporada, int? corridaOrder, bool ordenarPelosPontos)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.ObterPilotosTabela(temporada);
            var resultados = ResultadosService.GetResultadosPilotosTemporada(temporada);

            PreencherResultadosPilotosCorridas(corridas, pilotos, resultados);

            if (corridaOrder == null)
                pilotos.Sort((o, i) => o.Posicao.CompareTo(i.Posicao));
            else if (ordenarPelosPontos)
                pilotos.Sort((o, i) => OrdenarPorPontos(o.Resultados, i.Resultados, corridaOrder.Value));
            else
                pilotos.Sort((o, i) => OrdenarPorPosicaoChegada(o.Resultados, i.Resultados, corridaOrder.Value));

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }

        private int OrdenarPorPontos(List<ResultadoTemporada> resultados1, List<ResultadoTemporada> resultados2, int corridaId)
        {
            var resultadoCorrida1 = resultados1.FirstOrDefault(c => c.CorridaId == corridaId);
            var resultadoCorrida2 = resultados2.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida1 == null && resultadoCorrida2 == null) return 0;
            if (resultadoCorrida1 != null && resultadoCorrida2 == null) return -1;
            if (resultadoCorrida1 == null && resultadoCorrida2 != null) return 1;

            if (resultadoCorrida1?.PontosTotais == resultadoCorrida2?.PontosTotais)
                return (resultadoCorrida1?.PosicaoChegada ?? 0).CompareTo((resultadoCorrida2?.PosicaoChegada ?? 0));

            return (resultadoCorrida2?.PontosTotais ?? 0).CompareTo((resultadoCorrida1?.PontosTotais ?? 0));
        }

        private int OrdenarPorPosicaoChegada(List<ResultadoTemporada> resultados1, List<ResultadoTemporada> resultados2, int corridaId)
        {
            var resultadoCorrida1 = resultados1.FirstOrDefault(c => c.CorridaId == corridaId);
            var resultadoCorrida2 = resultados2.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida1 == null && resultadoCorrida2 == null) return 0;
            if (resultadoCorrida1 != null && resultadoCorrida2 == null) return -1;
            if (resultadoCorrida1 == null && resultadoCorrida2 != null) return 1;

            return (resultadoCorrida1?.PosicaoChegada ?? 0).CompareTo((resultadoCorrida2?.PosicaoChegada ?? 0));
        }

        private void PreencherResultadosPilotosCorridas(List<CorridaTemporada> corridas, List<PilotoTemporadaResultado> pilotos, List<ResultadoTemporada> resultados)
        {
            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }
    }
}
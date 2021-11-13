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
                pilotos.Sort((o, i) => ObterPontosTotais(i.Resultados, corridaOrder.Value).CompareTo(ObterPontosTotais(o.Resultados, corridaOrder.Value)));
            else
                pilotos.Sort((o, i) => ObterPosicaoChegada(o.Resultados, corridaOrder.Value).CompareTo(ObterPosicaoChegada(i.Resultados, corridaOrder.Value)));

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }

        private int ObterPosicaoChegada(List<ResultadoTemporada> resultados, int corridaId)
        {
            var resultadoCorrida = resultados.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida == null) return 999;

            return resultadoCorrida.PosicaoChegada;
        }

        private double ObterPontosTotais(List<ResultadoTemporada> resultados, int corridaId)
        {
            var resultadoCorrida = resultados.FirstOrDefault(c => c.CorridaId == corridaId);

            if (resultadoCorrida == null) return 0;

            return resultadoCorrida.PontosTotais;
        }

        private void PreencherResultadosPilotosCorridas(List<CorridaTemporada> corridas, List<PilotoTemporadaResultado> pilotos, List<ResultadoTemporada> resultados)
        {
            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());
            corridas.ForEach(f => f.Resultados = resultados.Where(o => o.CorridaId == f.Id).ToList());
        }
    }
}
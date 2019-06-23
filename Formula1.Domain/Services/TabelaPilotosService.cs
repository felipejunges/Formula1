using Formula1.Data.Models;
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

            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());

            if (order == null)
                pilotos.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));
            else
                pilotos.Sort((o, i) => o.Resultados[order.Value - 1].PosicaoChegada.CompareTo(i.Resultados[order.Value - 1].PosicaoChegada));

            return new TabelaCampeonatoPilotos(corridas, pilotos);
        }
    }
}
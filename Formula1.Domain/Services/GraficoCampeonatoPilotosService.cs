using Formula1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class GraficoCampeonatoPilotosService
    {
        private readonly TabelaPilotosService TabelaPilotosService;

        public GraficoCampeonatoPilotosService(TabelaPilotosService tabelaPilotosService)
        {
            TabelaPilotosService = tabelaPilotosService;
        }

        public GraficoCampeonatoPilotos GetGraficoCampeonatoPilotos(int temporada)
        {
            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(temporada, null, false);

            var pilotosGrafico = new List<PilotoPontosGrafico>();

            foreach (var piloto in campeonato.Pilotos)
            {
                var pontos = new double?[campeonato.Corridas.Count];

                double soma = 0;
                foreach (var corrida in campeonato.Corridas)
                {
                    if (!corrida.TemResultadosDeCorrida)
                        break;

                    var resultados = piloto.Resultados.Where(o => o.CorridaId == corrida.Id).ToList();
                    if (resultados.Any())
                        soma += resultados.Sum(s => s.Pontos);

                    pontos[campeonato.Corridas.IndexOf(corrida)] = soma;
                }

                pilotosGrafico.Add(new PilotoPontosGrafico()
                {
                    Piloto = piloto.NomeGuerra,
                    CorRgb = piloto.CorRgb,
                    Pontos = pontos
                });
            }

            var graficoCampeonato = new GraficoCampeonatoPilotos(campeonato.Corridas, pilotosGrafico, false);

            return graficoCampeonato;
        }

        public GraficoCampeonatoPilotos GetGraficoPontosPorCorrida(int temporada)
        {
            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(temporada, null, false);

            var pilotosGrafico = new List<PilotoPontosGrafico>();

            foreach (var piloto in campeonato.Pilotos)
            {
                var pontos = new double?[campeonato.Corridas.Count];

                foreach (var corrida in campeonato.Corridas)
                {
                    if (!corrida.TemResultadosDeCorrida)
                        break;

                    var resultado = piloto.Resultados.Where(o => o.CorridaId == corrida.Id).ToList();

                    pontos[campeonato.Corridas.IndexOf(corrida)] = resultado.Sum(s => s.Pontos);
                }

                pilotosGrafico.Add(new PilotoPontosGrafico()
                {
                    Piloto = piloto.NomeGuerra,
                    CorRgb = piloto.CorRgb,
                    Pontos = pontos
                });
            }

            return new GraficoCampeonatoPilotos(campeonato.Corridas, pilotosGrafico, true);
        }
    }
}
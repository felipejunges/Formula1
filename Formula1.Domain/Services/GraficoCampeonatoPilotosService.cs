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
            var campeonato = TabelaPilotosService.GetTabelaCampeonatoPilotos(temporada, null);

            var pilotosGrafico = new List<PilotoPontosGrafico>();

            foreach (var piloto in campeonato.Pilotos)
            {
                var pontos = new decimal?[campeonato.Corridas.Count];

                decimal soma = 0;
                foreach (var corrida in campeonato.Corridas)
                {
                    if (corrida.Resultados.Count == 0)
                        break;

                    var resultado = piloto.Resultados.FirstOrDefault(o => o.CorridaId == corrida.Id);
                    if (resultado != null)
                        soma += resultado.Pontos;

                    pontos[campeonato.Corridas.IndexOf(corrida)] = soma;
                }

                pilotosGrafico.Add(new PilotoPontosGrafico()
                {
                    Piloto = piloto.NomeGuerra,
                    CorRgb = piloto.CorRgb,
                    Pontos = pontos
                });
            }

            var graficoCampeonato = new GraficoCampeonatoPilotos(campeonato.Corridas, pilotosGrafico);

            return graficoCampeonato;
        }
    }
}
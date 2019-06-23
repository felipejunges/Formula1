using Formula1.Data.Models;
using System.Collections.Generic;

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
                var pontos = new int?[campeonato.Corridas.Count];
                for (int i = 0; i < piloto.Resultados.Count; i++)
                    pontos[i] = i == 0 ? piloto.Resultados[i].Pontos : pontos[i - 1] + piloto.Resultados[i].Pontos;

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
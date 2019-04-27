using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TemporadaService
    {
        private readonly F1Db Db;

        private readonly CorridasService CorridasService;
        private readonly EquipesService EquipesService;
        private readonly PilotosService PilotosService;
        private readonly ResultadosService ResultadosService;

        public TemporadaService(F1Db db, CorridasService corridasService, EquipesService equipesService, PilotosService pilotosService, ResultadosService resultadosService)
        {
            Db = db;
            Db.Database.EnsureCreated();

            CorridasService = corridasService;
            EquipesService = equipesService;
            PilotosService = pilotosService;
            ResultadosService = resultadosService;
        }

        public TabelaCampeonatoPilotosModel GetTabelaCampeonatoPilotos(int temporada)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var pilotos = PilotosService.GetPilotosTabela(temporada);
            var resultados = ResultadosService.GetResultadosPilotosTemporada(temporada);

            pilotos.ForEach(f => f.Resultados = resultados.Where(o => o.PilotoId == f.Id).ToList());

            pilotos.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));

            return new TabelaCampeonatoPilotosModel(corridas, pilotos);
        }

        public TabelaCampeonatoEquipesModel GetTabelaCampeonatoEquipes(int temporada)
        {
            var corridas = CorridasService.GetCorridasTabela(temporada);
            var equipes = EquipesService.GetEquipesTabela(temporada);
            var resultados = ResultadosService.GetResultadosEquipeTemporada(temporada);

            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());

            equipes.Sort((o, i) => i.PontosTemporada.CompareTo(o.PontosTemporada));

            return new TabelaCampeonatoEquipesModel(corridas, equipes);
        }

        public GraficoCampeonatoPilotos GetGraficoCampeonatoPilotos(int temporada)
        {
            var campeonato = GetTabelaCampeonatoPilotos(temporada);

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
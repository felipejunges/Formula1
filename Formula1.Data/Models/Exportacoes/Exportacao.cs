using System.Collections.Generic;

namespace Formula1.Data.Models.Exportacoes
{
    public class Exportacao
    {
        public List<PilotoExportacao> Pilotos { get; private set; }

        public List<EquipeExportacao> Equipes { get; private set; }

        public List<ContratoExportacao> Contratos { get; private set; }

        public List<CorridaExportacao> Corridas { get; private set; }

        public List<ResultadoExportacao> Resultados { get; private set; }

        public List<PunicaoExportacao> Punicoes { get; private set; }

        public List<PilotoTemporadaExportacao> PilotosTemporadas { get; private set; }

        public List<EquipeTemporadaExportacao> EquipesTemporadas { get; private set; }


        public Exportacao(
            List<PilotoExportacao> pilotos,
            List<EquipeExportacao> equipes,
            List<ContratoExportacao> contratos,
            List<CorridaExportacao> corridas,
            List<ResultadoExportacao> resultados,
            List<PunicaoExportacao> punicoes,
            List<PilotoTemporadaExportacao> pilotosTemporadas,
            List<EquipeTemporadaExportacao> equipesTemporadas)
        {
            Pilotos = pilotos;
            Equipes = equipes;
            Contratos = contratos;
            Corridas = corridas;
            Resultados = resultados;
            Punicoes = punicoes;
            PilotosTemporadas = pilotosTemporadas;
            EquipesTemporadas = equipesTemporadas;
        }
    }
}
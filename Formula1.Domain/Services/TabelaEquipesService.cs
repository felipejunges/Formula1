using Formula1.Data.Models;
using Formula1.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class TabelaEquipesService
    {
        private readonly ICorridasRepository _corridasRepository;
        private readonly IEquipesRepository _equipesRepository;
        private readonly IResultadosRepository _resultadosRepository;

        public TabelaEquipesService(ICorridasRepository corridasRepository, IEquipesRepository equipesRepository, IResultadosRepository resultadosRepository)
        {
            _corridasRepository = corridasRepository;
            _equipesRepository = equipesRepository;
            _resultadosRepository = resultadosRepository;
        }

        public TabelaCampeonatoEquipes GetTabelaCampeonatoEquipes(int temporada, int? corridaOrder)
        {
            var corridas = _corridasRepository.GetCorridasTabela(temporada);
            var equipes = _equipesRepository.ObterEquipesTabela(temporada);
            var resultados = _resultadosRepository.GetResultadosEquipeTemporada(temporada);

            PreencherResultadosEquipes(equipes, resultados);

            if (corridaOrder == null)
                equipes.Sort((o, i) => o.Posicao.CompareTo(i.Posicao));
            else
                equipes.Sort((o, i) => OrdenarPorPontos(o.Resultados, i.Resultados, corridaOrder.Value));

            return new TabelaCampeonatoEquipes(corridas, equipes);
        }

        private int OrdenarPorPontos(List<ResultadoTemporadaEquipe> resultados1, List<ResultadoTemporadaEquipe> resultados2, int corridaId)
        {
            var resultadoCorrida1 = resultados1.FirstOrDefault(c => c.CorridaId == corridaId && !c.Sprint);
            var resultadoCorrida2 = resultados2.FirstOrDefault(c => c.CorridaId == corridaId && !c.Sprint);

            if (resultadoCorrida1 == null && resultadoCorrida2 == null) return 0;
            if (resultadoCorrida1 == null) return 1;
            if (resultadoCorrida2 == null) return -1;

            return resultadoCorrida2.PontosTotais.CompareTo(resultadoCorrida1.PontosTotais);
        }

        private void PreencherResultadosEquipes(List<EquipeTemporadaResultado> equipes, List<ResultadoTemporadaEquipe> resultados)
        {
            equipes.ForEach(f => f.Resultados = resultados.Where(o => o.EquipeId == f.Id).ToList());
        }
    }
}
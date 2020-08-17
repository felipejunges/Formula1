using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class EquipeTemporadaService
    {
        private readonly F1Db Db;
        private readonly ResultadosService _resultadosService;
        private readonly PunicaoService _punicaoService;

        public EquipeTemporadaService(F1Db db, ResultadosService resultadosService, PunicaoService punicaoService)
        {
            Db = db;
            _resultadosService = resultadosService;
            _punicaoService = punicaoService;
        }

        public void CalcularEquipesTemporada(int temporada)
        {
            var resultados = _resultadosService.GetResultadosEquipeTemporada(temporada);
            var punicoes = _punicaoService.ObterPunicoesTemporada(temporada);

            var equipesIds = resultados.GroupBy(o => o.EquipeId).Select(o => o.Key).ToList();
            var equipesTemporada = new List<EquipeTemporadaInclusao>();

            foreach (var equipeId in equipesIds)
            {
                var pontos = 0;
                pontos += resultados.Where(o => o.EquipeId == equipeId).Sum(o => o.Pontos);
                pontos -= punicoes.Where(o => o.EquipeId == equipeId).Sum(o => o.Pontos);

                equipesTemporada.Add(new EquipeTemporadaInclusao(equipeId, temporada, pontos, 0));
            }

            equipesTemporada.Sort((o, i) =>
                    i.Pontos != o.Pontos
                        ? i.Pontos.CompareTo(o.Pontos)
                        : CompararEquipes(i.EquipeId, o.EquipeId, resultados));

            equipesTemporada.ForEach(o => o.Posicao = equipesTemporada.IndexOf(o) + 1);

            foreach (var equipeTemporada in equipesTemporada)
            {
                AddOrUpdate(equipeTemporada);
            }
        }

        private int CompararEquipes(int equipeId1, int equipeId2, List<ResultadoTemporada> resultados)
        {
            var maxPosicaoChegada = resultados.Max(o => o.PosicaoChegada);

            for (int i = 1; i <= maxPosicaoChegada; i++)
            {
                var quantidade1 = ObterQuantidadePosicoes(equipeId1, i, resultados);
                var quantidade2 = ObterQuantidadePosicoes(equipeId2, i, resultados);

                if (quantidade1 != quantidade2)
                    return quantidade1.CompareTo(quantidade2);
            }

            return 0;
        }

        private int ObterQuantidadePosicoes(int equipeId, int posicao, List<ResultadoTemporada> resultados)
        {
            return resultados.Where(o => o.EquipeId == equipeId && o.PosicaoChegada == posicao).Count();
        }

        private void AddOrUpdate(EquipeTemporadaInclusao equipeTemporadaInclusao)
        {
            var equipeTemporada = Db.EquipesTemporada.Where(o => o.Temporada == equipeTemporadaInclusao.Temporada && o.Equipe.Id == equipeTemporadaInclusao.EquipeId).FirstOrDefault();

            if (equipeTemporada == null)
            {
                var equipe = Db.Equipes.Find(equipeTemporadaInclusao.EquipeId);

                equipeTemporada = new EquipeTemporada()
                {
                    Id = 0,
                    Equipe = equipe,
                    Temporada = equipeTemporadaInclusao.Temporada
                };
            }

            equipeTemporada.Pontos = equipeTemporadaInclusao.Pontos;
            equipeTemporada.Posicao = equipeTemporadaInclusao.Posicao;

            if (equipeTemporada.Id == 0)
                Db.EquipesTemporada.Add(equipeTemporada);
            else
                Db.EquipesTemporada.Update(equipeTemporada);

            Db.SaveChanges();
        }
    }
}
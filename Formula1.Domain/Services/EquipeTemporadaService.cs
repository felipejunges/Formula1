using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class EquipeTemporadaService
    {
        private readonly F1Db Db;
        private readonly ResultadosService _resultadosService;
        private readonly CorridasService _corridasService;

        public EquipeTemporadaService(F1Db db, ResultadosService resultadosService, CorridasService corridasService)
        {
            Db = db;
            _resultadosService = resultadosService;
            _corridasService = corridasService;
        }

        public void CalcularEquipesTemporada(int temporada)
        {
            var resultados = _resultadosService.GetResultadosEquipeTemporada(temporada);

            var equipesIds = resultados.GroupBy(o => o.EquipeId).Select(o => o.Key).ToList();
            var equipesTemporada = new List<EquipeTemporadaInclusao>();

            foreach (var equipeId in equipesIds)
            {
                var pontos = resultados.Where(o => o.EquipeId == equipeId).Sum(o => o.PontosTotais);

                equipesTemporada.Add(new EquipeTemporadaInclusao(equipeId, temporada, pontos, 0, 0));
            }

            equipesTemporada.Sort((o, i) =>
                    i.Pontos != o.Pontos
                        ? i.Pontos.CompareTo(o.Pontos)
                        : CompararEquipes(i.EquipeId, o.EquipeId, resultados));

            equipesTemporada.ForEach(o => o.Posicao = equipesTemporada.IndexOf(o) + 1);

            // calcula a posição máxima de cada equipe
            MarcarEquipesPosicaoMaxima(equipesTemporada, temporada);

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

        private void MarcarEquipesPosicaoMaxima(List<EquipeTemporadaInclusao> equipes, int temporada)
        {
            double pontosRestantes = _corridasService.GetPontosEmDisputaEquipes(temporada);

            equipes.ForEach(f =>
                    f.PosicaoMaxima = pontosRestantes == 0
                        ? f.Posicao
                        : ObterPosicaoMaximaEquipePelosPontos(equipes, f, pontosRestantes)
                );
        }

        private static int ObterPosicaoMaximaEquipePelosPontos(List<EquipeTemporadaInclusao> equipes, EquipeTemporadaInclusao equipeIterada, double pontosRestantes)
        {
            var equipeComMaisPontos = equipes.Where(w => w.Pontos <= equipeIterada.Pontos + pontosRestantes).OrderByDescending(o => o.Pontos).FirstOrDefault();

            if (equipeComMaisPontos is null)
                return equipeIterada.Posicao;

            return equipes.IndexOf(equipeComMaisPontos) + 1;
        }

        private void AddOrUpdate(EquipeTemporadaInclusao equipeTemporadaInclusao)
        {
            var equipeTemporada = Db.EquipesTemporada.Where(o => o.Temporada == equipeTemporadaInclusao.Temporada && o.Equipe.Id == equipeTemporadaInclusao.EquipeId).FirstOrDefault();

            if (equipeTemporada == null)
            {
                var equipe = Db.Equipes.Find(equipeTemporadaInclusao.EquipeId);

                if (equipe is null)
                    return;

                equipeTemporada = new EquipeTemporada()
                {
                    Id = 0,
                    Equipe = equipe,
                    Temporada = equipeTemporadaInclusao.Temporada
                };
            }

            equipeTemporada.Pontos = equipeTemporadaInclusao.Pontos;
            equipeTemporada.Posicao = equipeTemporadaInclusao.Posicao;
            equipeTemporada.PosicaoMaxima = equipeTemporadaInclusao.PosicaoMaxima;

            if (equipeTemporada.Id == 0)
                Db.EquipesTemporada.Add(equipeTemporada);
            else
                Db.EquipesTemporada.Update(equipeTemporada);

            Db.SaveChanges();
        }
    }
}
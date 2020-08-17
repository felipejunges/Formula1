using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PilotoTemporadaService
    {
        private readonly F1Db Db;
        private readonly ResultadosService _resultadosService;
        private readonly PunicaoService _punicaoService;

        public PilotoTemporadaService(F1Db db, ResultadosService resultadosService, PunicaoService punicaoService)
        {
            Db = db;
            _resultadosService = resultadosService;
            _punicaoService = punicaoService;
        }

        public void CalcularPilotosTemporada(int temporada)
        {
            var resultados = _resultadosService.GetResultadosPilotosTemporada(temporada);
            var punicoes = _punicaoService.ObterPunicoesTemporada(temporada);

            var pilotosIds = resultados.GroupBy(o => o.PilotoId).Select(o => o.Key).ToList();
            var pilotosTemporada = new List<PilotoTemporadaInclusao>();

            foreach (var pilotoId in pilotosIds)
            {
                var pontos = 0;
                pontos += resultados.Where(o => o.PilotoId == pilotoId).Sum(o => o.Pontos);
                pontos -= punicoes.Where(o => o.PilotoId == pilotoId).Sum(o => o.Pontos);

                pilotosTemporada.Add(new PilotoTemporadaInclusao(pilotoId, temporada, pontos, 0));
            }

            pilotosTemporada.Sort((o, i) =>
                    i.Pontos != o.Pontos
                        ? i.Pontos.CompareTo(o.Pontos)
                        : CompararPilotos(i.PilotoId, o.PilotoId, resultados));

            pilotosTemporada.ForEach(o => o.Posicao = pilotosTemporada.IndexOf(o) + 1);

            foreach (var pilotoTemporada in pilotosTemporada)
            {
                AddOrUpdate(pilotoTemporada);
            }
        }

        private int CompararPilotos(int pilotoId1, int pilotoId2, List<ResultadoTemporada> resultados)
        {
            var maxPosicaoChegada = resultados.Max(o => o.PosicaoChegada);

            for (int i = 1; i <= maxPosicaoChegada; i++)
            {
                var quantidade1 = ObterQuantidadePosicoes(pilotoId1, i, resultados);
                var quantidade2 = ObterQuantidadePosicoes(pilotoId2, i, resultados);

                if (quantidade1 != quantidade2)
                    return quantidade1.CompareTo(quantidade2);
            }

            return 0;
        }

        private int ObterQuantidadePosicoes(int pilotoId, int posicao, List<ResultadoTemporada> resultados)
        {
            return resultados.Where(o => o.PilotoId == pilotoId && o.PosicaoChegada == posicao).Count();
        }

        private void AddOrUpdate(PilotoTemporadaInclusao pilotoTemporadaInclusao)
        {
            var pilotoTemporada = Db.PilotosTemporada.Where(o => o.Temporada == pilotoTemporadaInclusao.Temporada && o.Piloto.Id == pilotoTemporadaInclusao.PilotoId).FirstOrDefault();

            if (pilotoTemporada == null)
            {
                var piloto = Db.Pilotos.Find(pilotoTemporadaInclusao.PilotoId);

                pilotoTemporada = new PilotoTemporada()
                {
                    Id = 0,
                    Piloto = piloto,
                    Temporada = pilotoTemporadaInclusao.Temporada
                };
            }

            pilotoTemporada.Pontos = pilotoTemporadaInclusao.Pontos;
            pilotoTemporada.Posicao = pilotoTemporadaInclusao.Posicao;

            if (pilotoTemporada.Id == 0)
                Db.PilotosTemporada.Add(pilotoTemporada);
            else
                Db.PilotosTemporada.Update(pilotoTemporada);

            Db.SaveChanges();
        }
    }
}
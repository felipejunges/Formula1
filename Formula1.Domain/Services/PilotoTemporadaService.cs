using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PilotoTemporadaService
    {
        private readonly F1Db Db;
        private readonly ResultadosService _resultadosService;
        private readonly CorridasService _corridasService;

        public PilotoTemporadaService(F1Db db, ResultadosService resultadosService, CorridasService corridasService)
        {
            Db = db;
            _resultadosService = resultadosService;
            _corridasService = corridasService;
        }

        public void CalcularPilotosTemporada(int temporada)
        {
            var resultados = _resultadosService.GetResultadosPilotosTemporada(temporada);

            var pilotosIds = resultados.GroupBy(o => o.PilotoId).Select(o => o.Key).ToList();
            var pilotosTemporada = new List<PilotoTemporadaInclusao>();

            foreach (var pilotoId in pilotosIds)
            {
                var pontos = resultados.Where(o => o.PilotoId == pilotoId).Sum(o => o.Pontos);

                pilotosTemporada.Add(new PilotoTemporadaInclusao(pilotoId, temporada, pontos, 0, 0));
            }

            pilotosTemporada.Sort((o, i) =>
                    i.Pontos != o.Pontos
                        ? i.Pontos.CompareTo(o.Pontos)
                        : CompararPilotos(i.PilotoId, o.PilotoId, resultados));

            pilotosTemporada.ForEach(o => o.Posicao = pilotosTemporada.IndexOf(o) + 1);

            // calcula a posição máxima de cada piloto
            MarcarPilotosPosicaoMaxima(pilotosTemporada, temporada);

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
            return resultados.Where(o => o.PilotoId == pilotoId && o.PosicaoChegada == posicao && !o.DNF && !o.DSQ).Count();
        }

        private void MarcarPilotosPosicaoMaxima(List<PilotoTemporadaInclusao> pilotos, int temporada)
        {
            double pontosRestantes = _corridasService.GetPontosEmDisputaPilotos(temporada);

            pilotos.ForEach(f =>
                    f.PosicaoMaxima = pilotos.IndexOf(pilotos.Where(w => w.Pontos <= f.Pontos + pontosRestantes).OrderByDescending(o => o.Pontos).FirstOrDefault()) + 1
                );
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
            pilotoTemporada.PosicaoMaxima = pilotoTemporadaInclusao.PosicaoMaxima;

            if (pilotoTemporada.Id == 0)
                Db.PilotosTemporada.Add(pilotoTemporada);
            else
                Db.PilotosTemporada.Update(pilotoTemporada);

            Db.SaveChanges();
        }
    }
}
using Formula1.Data.Models;
using Formula1.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class PilotoTemporadaService
    {
        private readonly IPilotosTemporadaRepository _pilotosTemporadaRepository;
        private readonly IResultadosRepository _resultadosRepository;
        private readonly CorridasService _corridasService;

        public PilotoTemporadaService(IPilotosTemporadaRepository pilotosTemporadaRepository, IResultadosRepository resultadosRepository, CorridasService corridasService)
        {
            _pilotosTemporadaRepository = pilotosTemporadaRepository;
            _resultadosRepository = resultadosRepository;
            _corridasService = corridasService;
        }

        public void CalcularPilotosTemporada(int temporada)
        {
            var resultados = _resultadosRepository.GetResultadosPilotosTemporada(temporada);

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
                        : CompararPilotos(
                            i.PilotoId,
                            o.PilotoId,
                            resultados.Where(r => !r.Sprint).ToList()));

            pilotosTemporada.ForEach(o => o.Posicao = pilotosTemporada.IndexOf(o) + 1);

            // calcula a posição máxima de cada piloto
            MarcarPilotosPosicaoMaxima(pilotosTemporada, temporada);

            foreach (var pilotoTemporada in pilotosTemporada)
            {
                _pilotosTemporadaRepository.AddOrUpdate(pilotoTemporada);
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
                    f.PosicaoMaxima = pontosRestantes == 0
                                        ? f.Posicao
                                        : ObterPosicaoMaximaPilotoPelosPontos(pilotos, f, pontosRestantes)
                );
        }

        private static int ObterPosicaoMaximaPilotoPelosPontos(List<PilotoTemporadaInclusao> pilotos, PilotoTemporadaInclusao pilotoIterado, double pontosRestantes)
        {
            var pilotoComMaisPontos = pilotos.Where(w => w.Pontos <= pilotoIterado.Pontos + pontosRestantes).OrderByDescending(o => o.Pontos).FirstOrDefault();

            if (pilotoComMaisPontos is null)
                return pilotoIterado.Posicao;

            return pilotos.IndexOf(pilotoComMaisPontos) + 1;
        }
    }
}
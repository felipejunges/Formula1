using Formula1.Data.Entities;
using Formula1.Data.Models.Admin.Resultados;
using Formula1.Data.ValueObjects.CalculosPontos.Base;
using Formula1.Data.ValueObjects.CalculosPontos.Factories;
using Formula1.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class ResultadosService
    {
        private const int POSICOES_POR_CORRIDA = 20;

        private readonly IResultadosRepository _resultadosRepository;
        
        private readonly PilotoTemporadaService _pilotoTemporadaService;
        private readonly EquipeTemporadaService _equipeTemporadaService;

        public ResultadosService(
            IResultadosRepository resultadosRepository,
            PilotoTemporadaService pilotoTemporadaService,
            EquipeTemporadaService equipeTemporadaService)
        {
            _resultadosRepository = resultadosRepository;
            _pilotoTemporadaService = pilotoTemporadaService;
            _equipeTemporadaService = equipeTemporadaService;
        }

        public List<ResultadoItemDados> ObterListaResultados(Corrida corrida, bool sprint)
        {
            var resultados = _resultadosRepository.ObterListaResultados(corrida.Id, sprint);

            var calculo = CalculoPontosFactory.CriarCalculoPontos(corrida.Temporada, sprint);
            
            GrifarItensListaInvalidos(resultados, calculo);

            PreencherPosicoesFaltantes(resultados, calculo);

            return resultados;
        }

        private void PreencherPosicoesFaltantes(List<ResultadoItemDados> resultados, CalculoPontos calculoPontos)
        {
            var posicoesAtuais = resultados.Select(o => o.PosicaoChegada).ToList();
            var posicoesFaltantes = Enumerable.Range(1, POSICOES_POR_CORRIDA).Except(posicoesAtuais).ToList();

            foreach (var posicao in posicoesFaltantes)
            {
                resultados.Add(new ResultadoItemDados
                {
                    PosicaoChegada = posicao,
                    PontosCorrida = calculoPontos.CalcularPontos(posicao, false)
                });
            }

            resultados.Sort((a, b) => a.PosicaoChegada.CompareTo(b.PosicaoChegada));
        }

        public void PersistirResultadosCorrida(ResultadoListaDados resultadoListaDados)
        {
            foreach (var item in resultadoListaDados.Resultados)
            {
                if (item.DeveExcluirItem)
                {
                    var resultado = _resultadosRepository.ObterPeloId(item.IdAtual!.Value);

                    if (resultado is null)
                        throw new Exception("Resultado não encontrado");

                    _resultadosRepository.Excluir(resultado);
                }

                if (item.DevePersistirItem)
                {
                    var resultado = item.IdAtual.HasValue ? _resultadosRepository.ObterPeloId(item.IdAtual.Value) : new Resultado();

                    if (resultado is null)
                        throw new Exception("Resultado não encontrado");

                    resultado.Atualizar(
                        resultadoListaDados.CorridaId,
                        resultadoListaDados.CorridaSprint,
                        item.PilotoId!.Value,
                        item.EquipeId!.Value,
                        item.PosicaoChegada,
                        item.PontosCorrida,
                        item.VoltaMaisRapida,
                        item.DNF,
                        item.DSQ);

                    if (resultado.Id == 0)
                        _resultadosRepository.Incluir(resultado);
                    else
                        _resultadosRepository.Alterar(resultado);
                }
            }
            
            _pilotoTemporadaService.CalcularPilotosTemporada(resultadoListaDados.Temporada);
            _equipeTemporadaService.CalcularEquipesTemporada(resultadoListaDados.Temporada);
        }

        private void GrifarItensListaInvalidos(List<ResultadoItemDados> resultados, CalculoPontos calculoPontos)
        {
            // TODO: separar cada validação em um método

            // posição de chegada zerado
            resultados.Where(r => r.PosicaoChegada == 0).ToList().ForEach(r => r.GrifarChegada = true);

            // posições chegada repetidas
            var posicoesChegadaRepetidos = resultados.GroupBy(o => o.PosicaoChegada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoChegada = resultados.Where(o => posicoesChegadaRepetidos.Contains(o.PosicaoChegada)).ToList();

            itensPosicaoChegada.ForEach(o => o.GrifarChegada = true);

            // conferir os pontos da corrida
            resultados
                .Where(o => o.PontosCorrida != calculoPontos.CalcularPontos(o.PosicaoChegada, o.VoltaMaisRapida))
                .ToList()
                .ForEach(o => o.GrifarPontosCorrida = true);

            // pilotos com mais de dois resultados
            var pilotosRepetidos = resultados.GroupBy(o => o.PilotoId).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var pilotosGrifar = resultados.Where(o => pilotosRepetidos.Contains(o.PilotoId)).ToList();

            pilotosGrifar.ForEach(o => o.GrifarPiloto = true);

            // equipes com mais de dois resultados
            var equipesMais2Resultados = resultados.GroupBy(o => o.EquipeId).Where(o => o.Count() > 2).Select(o => o.Key).ToList();

            var equipesGrifar = resultados.Where(o => equipesMais2Resultados.Contains(o.EquipeId)).ToList();

            equipesGrifar.ForEach(o => o.GrifarEquipe = true);
        }
    }
}
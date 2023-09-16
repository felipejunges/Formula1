using Formula1.Data.Models.Admin.Resultados;
using Formula1.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Domain.Services
{
    public class ResultadosService
    {
        private readonly IResultadosRepository _resultadosRepository;

        public ResultadosService(IResultadosRepository resultadosRepository)
        {
            _resultadosRepository = resultadosRepository;
        }

        public List<ResultadoLista> ObterListaResultados(int corridaId)
        {
            var resultados = _resultadosRepository.ObterListaResultados(corridaId);
            
            GrifarItensListaInvalidos(resultados);

            return resultados;
        }

        private void GrifarItensListaInvalidos(List<ResultadoLista> resultados)
        {
            // posição de largada zerado
            resultados.Where(r => r.PosicaoLargada == 0).ToList().ForEach(r => r.GrifarLargada = true);

            // posição de chegada zerado
            resultados.Where(r => r.PosicaoChegada == 0).ToList().ForEach(r => r.GrifarChegada = true);

            // posições largada repetidas
            var posicoesLargadaRepetidos = resultados.GroupBy(o => o.PosicaoLargada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoLargada = resultados.Where(o => posicoesLargadaRepetidos.Contains(o.PosicaoLargada)).ToList();

            itensPosicaoLargada.ForEach(o => o.GrifarLargada = true);

            // posições chegada repetidas
            var posicoesChegadaRepetidos = resultados.GroupBy(o => o.PosicaoChegada).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPosicaoChegada = resultados.Where(o => posicoesChegadaRepetidos.Contains(o.PosicaoChegada)).ToList();

            itensPosicaoChegada.ForEach(o => o.GrifarChegada = true);

            // conferir os pontos da corrida
            resultados.Where(o => o.PontosCorrida != o.PontosCorridaCalculados).ToList().ForEach(o => o.GrifarPontosCorrida = true);

            // pontos classificação repetidos
            var pontosClassificacaoRepetidos = resultados.Where(o => o.PontosClassificacao > 0).GroupBy(o => o.PontosClassificacao).Where(o => o.Count() > 1).Select(o => o.Key).ToList();

            var itensPontoClassificacao = resultados.Where(o => pontosClassificacaoRepetidos.Contains(o.PontosClassificacao)).ToList();

            itensPontoClassificacao.ForEach(o => o.GrifarPontosClassificacao = true);

            // equipes com mais de dois resultados
            var equipesMais2Resultados = resultados.GroupBy(o => o.Equipe).Where(o => o.Count() > 2).Select(o => o.Key).ToList();

            var equipesGrifar = resultados.Where(o => equipesMais2Resultados.Contains(o.Equipe)).ToList();

            equipesGrifar.ForEach(o => o.GrifarEquipe = true);
        }
    }
}
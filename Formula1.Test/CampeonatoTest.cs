using Formula1.Test.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Formula1.Test
{
    public class CampeonatoTest : IClassFixture<ServiceFixture>
    {
        private readonly ServiceFixture ServiceFixture;

        public CampeonatoTest(ServiceFixture serviceFixture)
        {
            ServiceFixture = serviceFixture;
        }

        [Fact]
        public void NaoExistemPosicoesLargadaRepetidas()
        {
            var resultados = ServiceFixture.Db.Resultados.Include(o => o.Corrida).ToList();

            var groupPelaPosicaoLargada = resultados.GroupBy(o => new { o.Corrida.Id, o.PosicaoLargada });
            var quantidadeRepetidos = groupPelaPosicaoLargada.Where(o => o.Count() > 1).ToList();

            Assert.True(quantidadeRepetidos.Count() == 0);
        }

        [Fact]
        public void NaoExistemPosicoesChegadaRepetidas()
        {
            var resultados = ServiceFixture.Db.Resultados.Include(o => o.Corrida).ToList();

            var groupPelaPosicaoChegada = resultados.GroupBy(o => new { o.Corrida.Id, o.PosicaoChegada });
            var quantidadeRepetidos = groupPelaPosicaoChegada.Where(o => o.Count() > 1).ToList();

            Assert.True(quantidadeRepetidos.Count() == 0);
        }

        [Fact]
        public void TodasAsCorridasTemVinteResultados()
        {
            var corridas = ServiceFixture.Db.Corridas.Where(o => o.Resultados.Count != 0 && o.Resultados.Count != 20).ToList();

            Assert.Empty(corridas);
        }

        [Fact]
        public void TodasAsPosicoesBatemComOsPontos()
        {
            var resultados = ServiceFixture.Db.Resultados.ToList();

            var resultadosComPontosErrados = resultados.Where(o =>
                    (o.PosicaoChegada == 1 && o.Pontos != 25 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 2 && o.Pontos != 18 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 3 && o.Pontos != 15 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 4 && o.Pontos != 12 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 5 && o.Pontos != 10 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 6 && o.Pontos != 8 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 7 && o.Pontos != 6 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 8 && o.Pontos != 4 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 9 && o.Pontos != 2 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada == 10 && o.Pontos != 1 + (o.PontoExtra ? 1 : 0))
                    || (o.PosicaoChegada > 10 && o.Pontos > 0)
                );

            Assert.True(resultadosComPontosErrados.Count() == 0);
        }
    }
}
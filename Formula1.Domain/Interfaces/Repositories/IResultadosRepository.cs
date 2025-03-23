using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Resultados;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IResultadosRepository
    {
        Resultado? ObterPeloId(int id);

        List<ResultadoTemporadaPiloto> GetResultadosPilotosTemporada(int temporada);

        List<ResultadoTemporadaEquipe> GetResultadosEquipeTemporada(int temporada);

        List<ResultadoItemDados> ObterListaResultados(int corridaId, bool sprint);

        void Incluir(Resultado resultado);

        void Alterar(Resultado resultado);

        void Excluir(Resultado resultado);
    }
}
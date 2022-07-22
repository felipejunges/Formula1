using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Resultados;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IResultadosRepository
    {
        Resultado? ObterPeloId(int id);

        List<ResultadoTemporada> GetResultadosPilotosTemporada(int temporada);

        List<ResultadoTemporada> GetResultadosEquipeTemporada(int temporada);

        List<ResultadoLista> ObterListaResultados(int corridaId);

        void Incluir(ResultadoDados resultadoDados);

        void Alterar(ResultadoDados resultadoDados);

        void Excluir(Resultado resultado);
    }
}
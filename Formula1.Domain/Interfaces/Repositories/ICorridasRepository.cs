using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Corridas;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface ICorridasRepository
    {
        Corrida? ObterPeloId(int id);

        List<CorridaTemporada> GetCorridasTabela(int temporada);

        List<CorridaLista> GetCorridasLista(int temporada);

        List<Corrida> ObterCorridasRestantes(int temporada);

        void Incluir(CorridaDados corridaDados);

        void Alterar(CorridaDados corridaDados);

        void Excluir(Corrida corrida);
    }
}
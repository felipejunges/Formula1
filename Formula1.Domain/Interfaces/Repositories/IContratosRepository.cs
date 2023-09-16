using Formula1.Data.Entities;
using Formula1.Data.Models.Admin.Contratos;
using Formula1.Data.Models.Admin.Resultados;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IContratosRepository
    {
        Contrato? ObterPeloId(int id);

        List<ContratoLista> ObterContratosLista(int temporada);

        List<ResultadoEquipePilotos> ObterResultadoEquipesPilotos(int temporada);

        void Incluir(ContratoDados contratoDados);

        void Alterar(ContratoDados contratoDados);

        void Excluir(Contrato contrato);
    }
}
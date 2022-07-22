using Formula1.Data.Entities;
using Formula1.Data.Models;
using Formula1.Data.Models.Admin.Equipes;
using System.Collections.Generic;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IEquipesRepository
    {
        Equipe? ObterPeloId(int id);

        List<EquipeLista> ObterEquipesLista();

        List<Equipe> ObterEquipesAtivas();

        List<Equipe> ObterEquipesContrato(int temporada);

        List<EquipeTemporadaResultado> ObterEquipesTabela(int temporada);

        void Incluir(EquipeDados equipeDados);

        void Alterar(EquipeDados equipeDados);

        void Excluir(Equipe equipe);
    }
}
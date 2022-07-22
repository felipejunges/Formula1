using Formula1.Data.Models;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IEquipesTemporadaRepository
    {
        void AddOrUpdate(EquipeTemporadaInclusao equipeTemporadaInclusao);
    }
}
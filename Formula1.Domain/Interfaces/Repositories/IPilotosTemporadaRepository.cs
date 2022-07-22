using Formula1.Data.Models;

namespace Formula1.Domain.Interfaces.Repositories
{
    public interface IPilotosTemporadaRepository
    {
        void AddOrUpdate(PilotoTemporadaInclusao pilotoTemporadaInclusao);
    }
}
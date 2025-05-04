using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IForecastReports
    {
        Task<IEnumerable<ForecastReport>> GetAllAsync();
        Task AddAsync(ForecastReport forecastReport);
        Task DeleteAsync(int id);
        Task<ForecastReport> GetByIdAsync(int id);
        Task UpdateAsync(ForecastReport forecastReport);
    }
}

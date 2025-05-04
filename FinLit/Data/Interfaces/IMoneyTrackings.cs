using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IMoneyTrackings
    {
        Task<IEnumerable<MoneyTracking>> GetAllAsync();
        Task AddAsync(MoneyTracking moneyTracking);
        Task DeleteAsync(int id);
        Task<MoneyTracking> GetByIdAsync(int id);
        Task UpdateAsync(MoneyTracking moneyTracking);
    }
}

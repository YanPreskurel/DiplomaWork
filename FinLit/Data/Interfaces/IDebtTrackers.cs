using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IDebtTrackers
    {
        Task<IEnumerable<DebtTracker>> GetAllAsync();
        Task AddAsync(DebtTracker debtTracker);
        Task DeleteAsync(int id);
        Task<DebtTracker> GetByIdAsync(int id);
        Task UpdateAsync(DebtTracker debtTracker);
    }
}

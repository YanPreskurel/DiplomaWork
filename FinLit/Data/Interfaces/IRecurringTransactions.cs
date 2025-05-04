using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IRecurringTransactions
    {
        Task<IEnumerable<RecurringTransaction>> GetAllAsync();
        Task AddAsync(RecurringTransaction recurringTransaction);
        Task DeleteAsync(int id);
        Task<RecurringTransaction> GetByIdAsync(int id);
        Task UpdateAsync(RecurringTransaction recurringTransaction);
    }
}

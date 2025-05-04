using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactions
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task AddAsync(Transaction transaction);
        Task DeleteAsync(int id);
        Task<Transaction> GetByIdAsync(int id);
        Task UpdateAsync(Transaction transaction);
    }
}

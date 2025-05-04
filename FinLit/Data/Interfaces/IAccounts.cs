using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IAccounts
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
        Task DeleteAsync(int id);
        Task<Account> GetByIdAsync(int id);
        Task UpdateAsync(Account account);
    }
}

using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IFinancialGoalAccounts
    {
        Task<IEnumerable<FinancialGoalAccount>> GetAllAsync();
        Task AddAsync(FinancialGoalAccount financialGoalAccount);
        Task DeleteAsync(int id);
        Task<FinancialGoalAccount> GetByIdAsync(int id);
        Task UpdateAsync(FinancialGoalAccount financialGoalAccount);
    }
}

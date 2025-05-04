using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IExpenseReports
    {
        Task<IEnumerable<ExpenseReport>> GetAllAsync();
        Task AddAsync(ExpenseReport expenseReport);
        Task DeleteAsync(int id);
        Task<ExpenseReport> GetByIdAsync(int id);
        Task UpdateAsync(ExpenseReport expenseReport);
    }
}

using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IIncomeReports
    {
        Task<IEnumerable<IncomeReport>> GetAllAsync();
        Task AddAsync(IncomeReport incomeReport);
        Task DeleteAsync(int id);
        Task<IncomeReport> GetByIdAsync(int id);
        Task UpdateAsync(IncomeReport incomeReport);
    }
}

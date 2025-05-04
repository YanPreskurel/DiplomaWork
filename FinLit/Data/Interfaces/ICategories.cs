using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ICategories
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetAllIncomeCategoriesAsync();
        Task<IEnumerable<Category>> GetAllExpenseCategoriesAsync();
        Task AddAsync(Category category);
        Task DeleteAsync(int id);
        Task<Category> GetByIdAsync(int id);
    }
}

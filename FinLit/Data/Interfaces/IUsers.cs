using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IUsers
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
    }
}

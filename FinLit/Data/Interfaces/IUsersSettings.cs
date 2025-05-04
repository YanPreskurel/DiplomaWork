using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface IUsersSettings
    {
        Task<IEnumerable<UserSettings>> GetAllAsync();
        Task AddAsync(UserSettings userSettings);
        Task DeleteAsync(int id);
        Task<UserSettings> GetByIdAsync(int id);
        Task UpdateAsync(UserSettings userSettings);
    }
}

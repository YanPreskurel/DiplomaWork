using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface INotifications
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task AddAsync(Notification notification);
        Task DeleteAsync(int id);
        Task DeleteAllAsync(int userId);
        Task<Notification> GetByIdAsync(int id);
        Task UpdateAsync(Notification notification);
    }
}

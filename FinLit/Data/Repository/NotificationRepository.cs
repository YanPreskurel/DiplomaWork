using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class NotificationRepository : INotifications
    {
        private readonly DbContent dbContent;
        public NotificationRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public async Task AddAsync(Notification notification)
        {
            dbContent.Notifications.Add(notification);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(int userId)
        {
            var notifications = dbContent.Notifications.Where(n => n.UserId == userId);
            dbContent.Notifications.RemoveRange(notifications);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Notifications.FindAsync(id);

            if (obj != null)
            {
                dbContent.Notifications.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Notification>> GetAllAsync() => await dbContent.Notifications.OrderByDescending(n => n.DateSent).ToListAsync();
        public async Task<Notification> GetByIdAsync(int id)
        {
            var obj = await dbContent.Notifications.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Notification with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Notification notification)
        {
            dbContent.Notifications.Update(notification);
            await dbContent.SaveChangesAsync();
        }
    }
}

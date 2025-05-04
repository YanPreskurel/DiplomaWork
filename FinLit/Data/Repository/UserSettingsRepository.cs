using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class UserSettingsRepository : IUsersSettings
    {
        private readonly DbContent dbContent;
        public UserSettingsRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(UserSettings userSettings)
        {
            dbContent.UsersSettings.Add(userSettings);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.UsersSettings.FindAsync(id);

            if (obj != null)
            {
                dbContent.UsersSettings.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<UserSettings>> GetAllAsync() => await dbContent.UsersSettings.ToListAsync();
        public async Task<UserSettings> GetByIdAsync(int id)
        {
            var obj = await dbContent.UsersSettings.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"User Settings with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(UserSettings userSettings)
        {
            dbContent.UsersSettings.Update(userSettings);
            await dbContent.SaveChangesAsync();
        }
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class MoneyTrackingRepository : IMoneyTrackings
    {
        private readonly DbContent dbContent;
        public MoneyTrackingRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(MoneyTracking moneyTracking)
        {
            dbContent.MoneyTrackings.Add(moneyTracking);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.MoneyTrackings.FindAsync(id);

            if (obj != null)
            {
                dbContent.MoneyTrackings.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<MoneyTracking>> GetAllAsync() => await dbContent.MoneyTrackings.ToListAsync();
        public async Task<MoneyTracking> GetByIdAsync(int id)
        {
            var obj = await dbContent.MoneyTrackings.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"MoneyTracking with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(MoneyTracking moneyTracking)
        {
            dbContent.MoneyTrackings.Update(moneyTracking);
            await dbContent.SaveChangesAsync();
        }
    }
}

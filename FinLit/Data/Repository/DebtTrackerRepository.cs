using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace FinLit.Data.Repository
{
    public class DebtTrackerRepository : IDebtTrackers
    {
        private readonly DbContent dbContent;
        public DebtTrackerRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(DebtTracker debtTracker)
        {
            dbContent.DebtTrackers.Add(debtTracker);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.DebtTrackers.FindAsync(id);

            if(obj != null)
            {
                dbContent.DebtTrackers.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DebtTracker>> GetAllAsync() => await dbContent.DebtTrackers.ToListAsync();

        public async Task<DebtTracker> GetByIdAsync(int id)
        {
            var obj = await dbContent.DebtTrackers.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"Debt Tracker with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(DebtTracker debtTracker)
        {
            dbContent.DebtTrackers.Update(debtTracker);
            await dbContent.SaveChangesAsync();
        }
    }
}

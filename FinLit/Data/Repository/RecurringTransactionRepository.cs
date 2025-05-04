using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class RecurringTransactionRepository : IRecurringTransactions
    {
        private readonly DbContent dbContent;
        public RecurringTransactionRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(RecurringTransaction recurringTransaction)
        {
            dbContent.RecurringTransactions.Add(recurringTransaction);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.RecurringTransactions.FindAsync(id);

            if (obj != null)
            {
                dbContent.RecurringTransactions.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RecurringTransaction>> GetAllAsync() => await dbContent.RecurringTransactions.Include(t => t.Category).ToListAsync();

        public async Task<RecurringTransaction> GetByIdAsync(int id)
        {
            var obj = await dbContent.RecurringTransactions.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Recurring Transaction with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(RecurringTransaction recurringTransaction)
        {
            dbContent.RecurringTransactions.Update(recurringTransaction);
            await dbContent.SaveChangesAsync();
        }
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data.Repository
{
    public class TransactionRepository : ITransactions
    {
        private readonly DbContent dbContent;
        public TransactionRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public async Task AddAsync(Transaction transaction)
        {
            dbContent.Transactions.Add(transaction);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.Transactions.FindAsync(id);

            if(obj != null)
            {
                dbContent.Transactions.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync() => await dbContent.Transactions.Include(t => t.Category).OrderByDescending(t => t.Date).ToListAsync();

        public async Task<Transaction> GetByIdAsync(int id)
        {
            var obj = await dbContent.Transactions.FindAsync(id);

            if(obj is null)
            {
                throw new KeyNotFoundException($"Transaction with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            dbContent.Transactions.Update(transaction);
            await dbContent.SaveChangesAsync();
        }
    }
}

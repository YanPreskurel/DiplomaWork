using FinLit.Data.Interfaces;
using FinLit.Data.Models;

namespace FinLit.Data.Repository
{
    public class TransactionTagRepository : ITransactionTags
    {
        private readonly DbContent dbContent;
        public TransactionTagRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public async Task AddAsync(TransactionTag transactionTag)
        {
            dbContent.TransactionTags.Add(transactionTag);
            await dbContent.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.TransactionTags.FindAsync(id);

            if (obj != null)
            {
                dbContent.TransactionTags.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<TransactionTag> GetByIdAsync(int id)
        {
            var obj = await dbContent.TransactionTags.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Transaction Tag with id {id} not found.");
            }

            return obj;

        }
        public async Task UpdateAsync(TransactionTag transactionTag)
        {
            dbContent.TransactionTags.Update(transactionTag);
            await dbContent.SaveChangesAsync();
        }
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;

namespace FinLit.Data.Repository
{
    public class TransactionCommentRepository : ITransactionComments
    {
        private readonly DbContent dbContent;
        public TransactionCommentRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public async Task AddAsync(TransactionComment transactionComment)
        {
            dbContent.TransactionComments.Add(transactionComment);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.TransactionComments.FindAsync(id);

            if (obj != null)
            {
                dbContent.TransactionComments.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<TransactionComment> GetByIdAsync(int id)
        {
            var obj = await dbContent.TransactionComments.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Transaction Comment with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(TransactionComment transactionComment)
        {
            dbContent.TransactionComments.Update(transactionComment);
            await dbContent.SaveChangesAsync();
        }
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;

namespace FinLit.Data.Repository
{
    public class TransactionAttachmentRepository : ITransactionAttachments
    {
        private readonly DbContent dbContent;
        public TransactionAttachmentRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public async Task AddAsync(TransactionAttachment transactionAttachment)
        {
            dbContent.TransactionAttachments.Add(transactionAttachment);
            await dbContent.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await dbContent.TransactionAttachments.FindAsync(id);

            if (obj != null)
            {
                dbContent.TransactionAttachments.Remove(obj);
                await dbContent.SaveChangesAsync();
            }
        }

        public async Task<TransactionAttachment> GetByIdAsync(int id)
        {
            var obj = await dbContent.TransactionAttachments.FindAsync(id);

            if (obj is null)
            {
                throw new KeyNotFoundException($"Transaction Attachment with id {id} not found.");
            }

            return obj;
        }

        public async Task UpdateAsync(TransactionAttachment transactionAttachment)
        {
            dbContent.TransactionAttachments.Update(transactionAttachment);
            await dbContent.SaveChangesAsync();
        }
    }
}

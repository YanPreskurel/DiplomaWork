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
    }
}

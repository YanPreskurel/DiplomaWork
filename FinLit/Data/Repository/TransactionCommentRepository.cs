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
    }
}

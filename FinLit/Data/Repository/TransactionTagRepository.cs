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
    }
}

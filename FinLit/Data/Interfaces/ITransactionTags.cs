using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionTags
    {
        public Task AddAsync(TransactionTag transactionTag);
    }
}

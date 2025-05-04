using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionComments
    {
        public Task AddAsync(TransactionComment transactionComment);
    }
}

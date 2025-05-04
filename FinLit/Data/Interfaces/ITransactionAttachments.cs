using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionAttachments
    {
        public Task AddAsync(TransactionAttachment transactionAttachment);
    }
}

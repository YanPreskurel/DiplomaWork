using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionAttachments
    {
        Task AddAsync(TransactionAttachment transactionAttachment);
        Task DeleteAsync(int id);
        Task<TransactionAttachment> GetByIdAsync(int Id);
        Task UpdateAsync(TransactionAttachment transactionAttachment);
    }
}

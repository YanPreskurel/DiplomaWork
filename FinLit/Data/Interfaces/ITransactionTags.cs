using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionTags
    {
        Task AddAsync(TransactionTag transactionTag);
        Task DeleteAsync(int id);
        Task<TransactionTag> GetByIdAsync(int Id);
        Task UpdateAsync(TransactionTag transactionTag);

    }
}

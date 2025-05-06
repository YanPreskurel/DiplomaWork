using FinLit.Data.Models;

namespace FinLit.Data.Interfaces
{
    public interface ITransactionComments
    {
        Task AddAsync(TransactionComment transactionComment);
        Task DeleteAsync(int id);
        Task<TransactionComment> GetByIdAsync(int Id);
        Task UpdateAsync(TransactionComment transactionComment);
    }
}

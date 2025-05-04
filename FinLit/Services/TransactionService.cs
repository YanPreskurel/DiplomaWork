using FinLit.Data.Interfaces;
using FinLit.Data.Repository;

namespace FinLit.Services
{
    public class TransactionService
    {
        private readonly ITransactions transactionRepository;
        public TransactionService(ITransactions transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        //some functions
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;

namespace FinLit.Services
{
    public class FinancialGoalAccountService
    {
        private readonly IFinancialGoalAccounts financialGoalAccountsRepository;
        public FinancialGoalAccountService(IFinancialGoalAccounts financialGoalAccountsRepository)
        {
            this.financialGoalAccountsRepository = financialGoalAccountsRepository;
        }
        public async Task AddTransactionToFinancialGoalAccountAsync(decimal amount, int financialGoalAccountId)
        {
            var financialGoalAccount = await financialGoalAccountsRepository.GetByIdAsync(financialGoalAccountId);

            financialGoalAccount.Balance += amount;

            await financialGoalAccountsRepository.UpdateAsync(financialGoalAccount);
        }
    }
}

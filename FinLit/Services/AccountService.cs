using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;

namespace FinLit.Services
{
    public class AccountService
    {
        private readonly IAccounts accountsRepository;
        private readonly ICategories categoriesRepository;

        public AccountService(IAccounts accountsRepository, ICategories categoriesRepository)
        {
            this.accountsRepository = accountsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task AddTransactionToAccountAsync(Transaction transaction)
        {
            var account = await accountsRepository.GetByIdAsync(transaction.AccountId);
            var category = await categoriesRepository.GetByIdAsync(transaction.CategoryId);

            if (category.CategoryType == "Expense")
            {
                account.Balance -= transaction.Amount;
            }
            else
            {
                account.Balance += transaction.Amount;
            }

            await accountsRepository.UpdateAsync(account);
        }
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;

namespace FinLit.Services
{
    public class MoneyTrackingService
    {
        private readonly ITransactions transactionsRepository;
        private readonly IMoneyTrackings moneyTrackingsRepository;
        private readonly ICategories categoriesRepository;


        public MoneyTrackingService(ITransactions transactionsRepository, IMoneyTrackings moneyTrackingsRepository, ICategories categoriesRepository)
        {
            this.transactionsRepository = transactionsRepository;
            this.moneyTrackingsRepository = moneyTrackingsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task UpdateMoneyTrackingAsync(int accountId)
        {
            var moneyTracking = (await moneyTrackingsRepository.GetAllAsync()).FirstOrDefault(mt => mt.AccountId == accountId);

            if (moneyTracking == null)
                return;

            moneyTracking.Amount = 0;

            var transactions = await transactionsRepository.GetAllAsync();
            var categories = await categoriesRepository.GetAllAsync();

            moneyTracking.StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToUniversalTime();
            moneyTracking.EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1).ToUniversalTime();

            foreach (var transaction in transactions)
            {
                if (transaction.AccountId == accountId && transaction.Date >= moneyTracking.StartDate && transaction.Date <= moneyTracking.EndDate)
                {
                    var category = categories.FirstOrDefault(c => c.Id == transaction.CategoryId);
                    if (category != null && category.CategoryType == "Expense")
                    {
                        moneyTracking.Amount += transaction.Amount;
                    }
                }
            }

            await moneyTrackingsRepository.UpdateAsync(moneyTracking);
        }
    }
}

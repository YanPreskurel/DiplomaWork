using FinLit.Data.Interfaces;
using FinLit.Data.Models;

namespace FinLit.Services
{
    public class CategoryService
    {
        private readonly ICategories categoriesRepository;
        private readonly ITransactions transactionsRepository;
        public CategoryService(ICategories categoriesRepository, ITransactions transactionsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.transactionsRepository = transactionsRepository;
        }

        public async Task ReplaceDeletedCategory(Category category)
        {
            var transactions = (await transactionsRepository.GetAllAsync()).Where(t => t.CategoryId == category.Id);

            var defaultCategory = (await categoriesRepository.GetAllAsync()).FirstOrDefault(c => c.UserId == category.UserId && c.CategoryName == "Другое" && c.CategoryType == category.CategoryType);
            
            if (defaultCategory == null)
                throw new InvalidOperationException("Категория 'Другое' не найдена.");

            foreach (var transaction in transactions)
            {
                transaction.CategoryId = defaultCategory.Id;
                await transactionsRepository.UpdateAsync(transaction);
            }
        }
    }
}

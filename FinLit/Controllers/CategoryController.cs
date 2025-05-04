using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategories categoriesRepository; 
        public CategoryController(ICategories categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryView()
        {
            var userId = GetUserIdOrRedirect();

            var incomeCategories = (await categoriesRepository.GetAllIncomeCategoriesAsync())
                    .Where(c => c.UserId == userId);
            var expenseCategories = (await categoriesRepository.GetAllExpenseCategoriesAsync())
                .Where(c => c.UserId == userId);

            var model = new CategoryFormViewModel
            {
                IncomeCategories = incomeCategories,
                ExpenseCategories = expenseCategories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryFormViewModel model)
        {
            var userId = GetUserIdOrRedirect();

            var newCategory = new Category
            {
                CategoryName = model.CategoryName ?? "",
                CategoryType = model.CategoryType ?? "Expense",
                CategoryImage = model.CategoryImage,
                UserId = (int)userId
            };

            await categoriesRepository.AddAsync(newCategory);
            return RedirectToAction("CategoryView");
        }
    }
}

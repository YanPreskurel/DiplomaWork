using FinLit.Data.Enums;
using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.Services;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategories categoriesRepository; 
        private readonly CategoryService categoryService; 
        public CategoryController(ICategories categoriesRepository, CategoryService categoryService)
        {
            this.categoriesRepository = categoriesRepository;
            this.categoryService = categoryService;
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
                UserId = userId
            };

            await categoriesRepository.AddAsync(newCategory);
            return RedirectToAction("CategoryView");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = GetUserIdOrRedirect();

            var category = await categoriesRepository.GetByIdAsync(id);

            if (category.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            if (category.CategoryName != "Другое")
            {
                await categoryService.ReplaceDeletedCategory(category);
                await categoriesRepository.DeleteAsync(id);
            }
            return RedirectToAction("CategoryView");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var userId = GetUserIdOrRedirect();

            var category = await categoriesRepository.GetByIdAsync(id);

            if (category.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            var model = new CategoryFormViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName, 
                CategoryType = category.CategoryType, 
                CategoryImage = category.CategoryImage
            };

            return View("EditCategoryView", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryFormViewModel model)
        {
            var userId = GetUserIdOrRedirect();

            if (!ModelState.IsValid)
                return View("EditCategoryView", model);

            var category = await categoriesRepository.GetByIdAsync(model.Id);
            if (category.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            category.CategoryName = model.CategoryName;
            category.CategoryImage = model.CategoryImage;

            await categoriesRepository.UpdateAsync(category);

            return RedirectToAction("CategoryView");
        }
    }
}

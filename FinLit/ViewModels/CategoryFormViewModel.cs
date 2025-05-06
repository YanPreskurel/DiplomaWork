using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string? CategoryType { get; set; } // "Income" or "Expense"
        public string? CategoryImage { get; set; }

        public IEnumerable<Category> IncomeCategories { get; set; } = new List<Category>();
        public IEnumerable<Category> ExpenseCategories { get; set; } = new List<Category>();
    }
}

using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Services
{
    public class ReportService
    {
        private readonly ITransactions transactionsRepository;
        private readonly ICategories categoriesRepository;

        public ReportService(ITransactions transactionsRepository, ICategories categoriesRepository)
        {
            this.transactionsRepository = transactionsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<ReportViewModel> GetReportViewModelAsync(int selectedAccountId)
        {
            var transactions = await transactionsRepository.GetAllAsync();
            var categories = await categoriesRepository.GetAllAsync();

            var incomeReportViewModels = BuildIncomeReports(transactions, categories, selectedAccountId);
            var expenseReportViewModels = BuildExpenseReports(transactions, categories, selectedAccountId);
            var forecastReport = BuildForecastReports(transactions, categories, selectedAccountId);

            return new ReportViewModel
            {
                IncomeReportViewModels = incomeReportViewModels,
                ExpenseReportViewModels = expenseReportViewModels,
                ForecastReport = forecastReport
            };
        }

        private IEnumerable<IncomeReportViewModel> BuildIncomeReports(IEnumerable<Transaction> transactions, IEnumerable<Category> categories, int selectedAccountId)
        {
            var incomeCategoryIds = categories.Where(c => c.CategoryType == "Income").Select(c => c.Id);

            var filteredTransactions = transactions.Where(t => t.AccountId == selectedAccountId && incomeCategoryIds.Contains(t.CategoryId));

            var groupedByMonth = filteredTransactions.GroupBy(t => new { t.Date.Year, t.Date.Month });

            var reports = new List<IncomeReportViewModel>();

            foreach (var group in groupedByMonth)
            {
                var report = new IncomeReportViewModel
                {

                    IncomeReport = new IncomeReport
                    {
                        StartDate = new DateTime(group.Key.Year, group.Key.Month, 1),
                        EndDate = new DateTime(group.Key.Year, group.Key.Month, DateTime.DaysInMonth(group.Key.Year, group.Key.Month)),
                        TotalIncomes = group.Sum(t => t.Amount),
                        ReportType = "Month",
                        UserId = group.First().UserId
                    },

                    Transactions = group.Select(t => new IncomeTransactionDto
                    {
                        Date = t.Date,
                        Amount = t.Amount,
                        Category = t.Category.CategoryName
                    }).ToList()
                };

                reports.Add(report);
            }

            return reports;
        }

        private IEnumerable<ExpenseReportViewModel> BuildExpenseReports(IEnumerable<Transaction> transactions, IEnumerable<Category> categories, int selectedAccountId)
        {
            var expenseCategoryIds = categories.Where(c => c.CategoryType == "Expense").Select(c => c.Id);

            var filteredTransactions = transactions.Where(t => t.AccountId == selectedAccountId && expenseCategoryIds.Contains(t.CategoryId));

            var groupedByMonth = filteredTransactions.GroupBy(t => new { t.Date.Year, t.Date.Month });

            var reports = new List<ExpenseReportViewModel>();

            foreach (var group in groupedByMonth)
            {
                var report = new ExpenseReportViewModel
                {
                    ExpenseReport = new ExpenseReport
                    {
                        StartDate = new DateTime(group.Key.Year, group.Key.Month, 1),
                        EndDate = new DateTime(group.Key.Year, group.Key.Month, DateTime.DaysInMonth(group.Key.Year, group.Key.Month)),
                        TotalExpenses = group.Sum(t => t.Amount),
                        ReportType = "Month",
                        UserId = group.First().UserId
                    },

                    Transactions = group.Select(t => new ExpenseTransactionDto
                    {
                        Date = t.Date,
                        Amount = t.Amount,
                        Category = t.Category.CategoryName
                    }).ToList()
                };

                reports.Add(report);
            }

            return reports;
        }

        private ForecastReport BuildForecastReports(IEnumerable<Transaction> transactions, IEnumerable<Category> categories, int selectedAccountId)
        {
            // Получаем транзакции пользователя за последние 3 месяца
            var lastTransactions = transactions.Where(t => t.AccountId == selectedAccountId && t.Date >= DateTime.Today.AddMonths(-3));

            if (!lastTransactions.Any())
            {
                throw new InvalidOperationException("Недостаточно данных для прогноза.");
            }

            // Считаем только расходы
            var totalExpenses = lastTransactions.Where(t => t.CategoryId != 0 && categories.Any(c => c.Id == t.CategoryId && c.CategoryType == "Expense")).Sum(t => t.Amount);

            // Средний расход за месяц
            var averageExpenses = totalExpenses / 3;

            var forecast = new ForecastReport
            {
                UserId = lastTransactions.First().UserId,
                TotalExpenses = averageExpenses,
                StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1), // начало следующего месяца
                EndDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(2).AddDays(-1) // конец следующего месяца
            };

            return forecast;
        }
    }
}

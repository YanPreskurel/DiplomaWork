using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.Services;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Transaction = FinLit.Data.Models.Transaction;

namespace FinLit.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactions transactionsRepository;
        private readonly ICategories categoriesRepository;
        private readonly ITransactionComments transactionCommentsRepository;
        private readonly ITransactionTags transactionTagsRepository;
        private readonly ITransactionAttachments transactionAttachmentsRepository;
        private readonly IAccounts accountsRepository;
        private readonly AccountService accountService;
        private readonly MoneyTrackingService moneyTrackingService;
        public TransactionController(ITransactions transactionsRepository,
            ICategories categoriesRepository,
            ITransactionComments transactionCommentsRepository,
            ITransactionTags transactionTagsRepository,
            ITransactionAttachments transactionAttachmentsRepository,
            IAccounts accountsRepository,
            AccountService accountService,
            MoneyTrackingService moneyTrackingService)
        {
            this.transactionsRepository = transactionsRepository;
            this.categoriesRepository = categoriesRepository;
            this.transactionCommentsRepository = transactionCommentsRepository;
            this.transactionTagsRepository = transactionTagsRepository;
            this.transactionAttachmentsRepository = transactionAttachmentsRepository;
            this.accountService = accountService;
            this.moneyTrackingService = moneyTrackingService;
            this.accountsRepository = accountsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> TransactionView(string operationType = "All", DateTime? startDate = null, DateTime? endDate = null, int? selectedCategoryId = null)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("AuthentificationView", "User");
            }

            var transactions = await transactionsRepository.GetAllAsync();
            
            foreach(var transaction in transactions)
            {
                transaction.Category = await categoriesRepository.GetByIdAsync(transaction.CategoryId);
            }

            // Фильтрация по типу

            if (operationType == "Income")
                transactions = transactions.Where(t => t.Category.CategoryType == "Income").ToList();
            else if (operationType == "Expense")
                transactions = transactions.Where(t => t.Category.CategoryType == "Expense").ToList();


            // Фильтрация по дате
            var start = startDate?.Date ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var end = (endDate?.Date.AddDays(1).AddSeconds(-1)) ?? DateTime.Today.AddDays(1).AddSeconds(-1);

            transactions = transactions.Where(t => t.Date >= start && t.Date <= end);

            // Фильтрация по категории
            if (selectedCategoryId.HasValue)
                transactions = transactions.Where(t => t.CategoryId == selectedCategoryId.Value);

            var model = new TransactionCategoryViewModel
            {
                Transactions = transactions,
                Categories = (await categoriesRepository.GetAllAsync()).Where(c => operationType == "All" || c.CategoryType == operationType).ToList(),
                Accounts = await accountsRepository.GetAllAsync(),
                OperationType = operationType,
                StartDate = start,
                EndDate = end,
                SelectedCategoryId = selectedCategoryId
            };


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTransactionView()
        {
            var model = new TransactionFormViewModel
            {
                Categories = await categoriesRepository.GetAllAsync()
            };

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetFilteredTransactions(string operationType = "All", DateTime? startDate = null, DateTime? endDate = null, int? selectedCategoryId = null)
        //{
        //    var userId = HttpContext.Session.GetInt32("UserId");
        //    if (userId == null) return Unauthorized();

        //    var transactions = await transactionsRepository.GetAllAsync();

        //    foreach (var transaction in transactions)
        //        transaction.Category = await categoriesRepository.GetByIdAsync(transaction.CategoryId);

        //    if (operationType == "Income")
        //        transactions = transactions.Where(t => t.Category.CategoryType == "Income").ToList();
        //    else if (operationType == "Expense")
        //        transactions = transactions.Where(t => t.Category.CategoryType == "Expense").ToList();

        //    var start = startDate?.Date ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        //    var end = (endDate?.Date.AddDays(1).AddSeconds(-1)) ?? DateTime.Today.AddDays(1).AddSeconds(-1);
        //    transactions = transactions.Where(t => t.Date >= start && t.Date <= end).ToList();

        //    if (selectedCategoryId.HasValue)
        //        transactions = transactions.Where(t => t.CategoryId == selectedCategoryId.Value).ToList();

        //    var allCategories = await categoriesRepository.GetAllAsync();
        //    var filteredCategories = operationType == "All"
        //        ? allCategories
        //        : allCategories.Where(c => c.CategoryType == operationType).ToList();

        //    // ✅ собираем реальные объекты, не Task
        //    var transactionDtos = new List<object>();
        //    foreach (var t in transactions)
        //    {
        //        var account = await accountsRepository.GetByIdAsync(t.AccountId);
        //        transactionDtos.Add(new
        //        {
        //            AccountName = account?.Name ?? "Неизвестно",
        //            Currency = account?.Currency ?? "",
        //            t.Amount,
        //            Date = t.Date.ToLocalTime().ToString("dd.MM.yyyy"),
        //            Time = t.Date.ToLocalTime().ToString("HH:mm"),
        //            CategoryName = t.Category.CategoryName,
        //            Type = t.Category.CategoryType
        //        });
        //    }

        //    return Json(new
        //    {
        //        transactions = transactionDtos,
        //        categories = filteredCategories.Select(c => new { c.Id, c.CategoryName })
        //    });
        //}



        [HttpPost]
        public async Task<IActionResult> AddTransaction(TransactionFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    Console.WriteLine("User ID не найден в сессии.");
                    return RedirectToAction("AuthentificationView", "User");
                }

                var selectedAccountId = HttpContext.Session.GetInt32("SelectedAccountId") ?? 1; // добавить строку что либо выбранный акканут либо дефолтный потом в дальнейшем во вкладке персонализации

                var category = await categoriesRepository.GetByIdAsync(model.CategoryId);
                if (category == null)
                {
                    return BadRequest("Категория не найдена");
                }

                // Создаём комментарий
                var comment = new TransactionComment { CommentText = model.CommentText ?? "", UserId = (int)userId };
                await transactionCommentsRepository.AddAsync(comment);

                // Создаём тег
                var tag = new TransactionTag { TagName = model.TagName ?? "", UserId = (int)userId };
                await transactionTagsRepository.AddAsync(tag);

                // Создаём вложение
                var attachment = new TransactionAttachment { FilePath = model.AttachmentUrl ?? "", UserId = (int)userId };
                await transactionAttachmentsRepository.AddAsync(attachment);

                // Создаём транзакцию
                var transaction = new Transaction
                {
                    UserId = userId.Value,
                    Amount = model.Amount,
                    Date = DateTime.Now.ToUniversalTime(),
                    CategoryId = model.CategoryId,
                    AccountId = selectedAccountId,
                    TransactionCommentId = comment.Id,
                    TransactionTagId = tag.Id,
                    TransactionAttachmentId = attachment.Id
                };

                await transactionsRepository.AddAsync(transaction);
                await accountService.AddTransactionToAccountAsync(transaction);
                await moneyTrackingService.UpdateMoneyTrackingAsync(transaction.AccountId);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}

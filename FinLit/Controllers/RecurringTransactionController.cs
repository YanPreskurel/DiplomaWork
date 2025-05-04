using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.Services;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinLit.Controllers
{
    public class RecurringTransactionController : Controller
    {
        private readonly IRecurringTransactions recurringTransactionsRepository;
        private readonly ITransactions transactionsRepository;
        private readonly ICategories categoriesRepository;
        private readonly ITransactionComments transactionCommentsRepository;
        private readonly ITransactionTags transactionTagsRepository;
        private readonly ITransactionAttachments transactionAttachmentsRepository;
        private readonly IAccounts accountsRepository;
        private readonly AccountService accountService;
        private readonly MoneyTrackingService moneyTrackingService;
        public RecurringTransactionController(IRecurringTransactions recurringTransactionsRepository, ITransactions transactionsRepository,
            ICategories categoriesRepository,
            ITransactionComments transactionCommentsRepository,
            ITransactionTags transactionTagsRepository,
            ITransactionAttachments transactionAttachmentsRepository,
            IAccounts accountsRepository,
            AccountService accountService,
            MoneyTrackingService moneyTrackingService)
        {
            this.recurringTransactionsRepository = recurringTransactionsRepository;
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
        public async Task<IActionResult> CalendarView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var categories = (await categoriesRepository.GetAllAsync()).Where(c => c.UserId == userId && c.CategoryType == "Expense");

            var model = new RecurringTransactionFormViewModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecurringTransaction(RecurringTransactionFormViewModel model)
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
                var recurringTransaction = new RecurringTransaction
                {
                    UserId = userId.Value,
                    Amount = model.Amount,
                    Frequency = model.Frequency ?? "",
                    OccurrenceDate = model.OccurrenceDate.ToUniversalTime(),
                    CategoryId = model.CategoryId,
                    AccountId = selectedAccountId, // Здесь нужно будет указать правильный AccountId
                    TransactionCommentId = comment.Id,
                    TransactionTagId = tag.Id,
                    TransactionAttachmentId = attachment.Id
                };

                await recurringTransactionsRepository.AddAsync(recurringTransaction);

                if(recurringTransaction.OccurrenceDate <= DateTime.Now.ToUniversalTime()) // если дата добавления до нынешней или раван ей добавляем транзакцию
                {
                    var transaction = new Transaction
                    {
                        UserId = userId.Value,
                        Amount = model.Amount,
                        Date = model.OccurrenceDate.ToUniversalTime(),
                        CategoryId = model.CategoryId,
                        AccountId = selectedAccountId,
                        TransactionCommentId = comment.Id,
                        TransactionTagId = tag.Id,
                        TransactionAttachmentId = attachment.Id
                    };

                    await transactionsRepository.AddAsync(transaction);
                    await accountService.AddTransactionToAccountAsync(transaction);
                    await moneyTrackingService.UpdateMoneyTrackingAsync(transaction.AccountId);
                }

                return RedirectToAction("CalendarView", "RecurringTransaction");
            }
            return View(model);
        }
    }
}

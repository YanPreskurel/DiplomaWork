using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;

namespace FinLit.Services
{
    public class RecurringTransactionService
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
        public RecurringTransactionService(IRecurringTransactions recurringTransactionsRepository, ITransactions transactionsRepository,
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

        public async Task AddRecurringTransactionToTransactionList()
        {
            var recurringTransactions = await recurringTransactionsRepository.GetAllAsync();

            foreach (var recurringTransaction in recurringTransactions)
            {

                if (recurringTransaction.OccurrenceDate <= DateTime.Now.ToUniversalTime()) 
                {
                    var transaction = new Transaction
                    {
                        UserId = recurringTransaction.UserId,
                        Amount = recurringTransaction.Amount,
                        Date = recurringTransaction.OccurrenceDate.ToUniversalTime(),
                        CategoryId = recurringTransaction.CategoryId,
                        AccountId = recurringTransaction.AccountId,
                        TransactionCommentId = recurringTransaction.TransactionCommentId,
                        TransactionTagId = recurringTransaction.TransactionTagId,
                        TransactionAttachmentId = recurringTransaction.TransactionAttachmentId
                    };

                    await transactionsRepository.AddAsync(transaction);
                    await accountService.AddTransactionToAccountAsync(transaction);
                    await moneyTrackingService.UpdateMoneyTrackingAsync(transaction.AccountId);

                    if (recurringTransaction.Frequency == "Day")
                        recurringTransaction.OccurrenceDate = recurringTransaction.OccurrenceDate.AddDays(1);
                    else if (recurringTransaction.Frequency == "Month")
                        recurringTransaction.OccurrenceDate = recurringTransaction.OccurrenceDate.AddMonths(1);
                    else
                        recurringTransaction.OccurrenceDate = recurringTransaction.OccurrenceDate.AddYears(1);

                    await recurringTransactionsRepository.UpdateAsync(recurringTransaction);
                }
            }

        }
    }
    public class RecurringTransactionWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RecurringTransactionWorker> _logger;

        public RecurringTransactionWorker(IServiceProvider serviceProvider, ILogger<RecurringTransactionWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var recurringService = scope.ServiceProvider.GetRequiredService<RecurringTransactionService>();

                    await recurringService.AddRecurringTransactionToTransactionList();

                    //var delay = await GetNextDelayAsync(scope);
                    //_logger.LogInformation($"RecurringTransactionWorker sleeping for {delay}.");

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while processing recurring transactions.");
                    await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
                }
            }
        }

        // Метод, чтобы фоновое выполнение откладвалось до следующего времени для разгрузки системы 
        private async Task<TimeSpan> GetNextDelayAsync(IServiceScope scope)
        {
            var repo = scope.ServiceProvider.GetRequiredService<IRecurringTransactions>();

            var recurringTransactions = await repo.GetAllAsync();
            var nextTransaction = recurringTransactions
                .Where(rt => rt.OccurrenceDate > DateTime.UtcNow)
                .OrderBy(rt => rt.OccurrenceDate)
                .FirstOrDefault();

            if (nextTransaction != null)
            {
                var now = DateTime.UtcNow;
                var waitTime = nextTransaction.OccurrenceDate - now;
                return waitTime > TimeSpan.Zero ? waitTime : TimeSpan.Zero;
            }

            // Если нет будущих дат час ждем
            return TimeSpan.FromHours(1);
        }
    }
}

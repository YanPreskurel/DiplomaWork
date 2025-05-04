using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Data
{
    public class DbContent : DbContext
    {
        public DbContent(DbContextOptions<DbContent> options) : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DebtTracker> DebtTrackers { get; set; }
        public DbSet<ExpenseReport> ExpenseReports { get; set; }
        public DbSet<MoneyTracking> MoneyTrackings { get; set; }
        public DbSet<FinancialGoalAccount> FinancialGoalAccounts { get; set; }
        public DbSet<ForecastReport> ForecastReports { get; set; }
        public DbSet<IncomeReport> IncomeReports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Personalization> Personalizations { get; set; }
        public DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionAttachment> TransactionAttachments { get; set; }
        public DbSet<TransactionComment> TransactionComments { get; set; }
        public DbSet<TransactionTag> TransactionTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UsersSettings { get; set; }

    }
}

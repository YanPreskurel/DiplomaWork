using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinLit.Data
{
    public class DbTestObjects
    {
        public static void Initial(DbContent dbContent)
        {
            if (!dbContent.Accounts.Any())
            {
                dbContent.Accounts.AddRange(AccountTestObjects);
            }
            if (!dbContent.ActivityLogs.Any())
            {
                dbContent.ActivityLogs.AddRange(ActivityLogTestObjects);
            }
            if (!dbContent.Categories.Any())
            {
                dbContent.Categories.AddRange(CategoryTestObjects);
            }
            if (!dbContent.DebtTrackers.Any())
            {
                dbContent.DebtTrackers.AddRange(DebtTrackerTestObjects);
            }
            if (!dbContent.ExpenseReports.Any())
            {
                dbContent.ExpenseReports.AddRange(ExpenseReportTestObjects);
            }
            if (!dbContent.MoneyTrackings.Any())
            {
                dbContent.MoneyTrackings.AddRange(MoneyTrackingTestObjects);
            }
            if (!dbContent.FinancialGoalAccounts.Any())
            {
                dbContent.FinancialGoalAccounts.AddRange(FinancialGoalAccountTestObjects);
            }
            if (!dbContent.IncomeReports.Any())
            {
                dbContent.IncomeReports.AddRange(IncomeReportTestObjects);
            }
            if (!dbContent.Notifications.Any())
            {
                dbContent.Notifications.AddRange(NotificationTestObjects);
            }
            if (!dbContent.Personalizations.Any())
            {
                dbContent.Personalizations.AddRange(PersonalizationTestObjects);
            }
            if (!dbContent.RecurringTransactions.Any())
            {
                dbContent.RecurringTransactions.AddRange(RecurringTransactionTestObjects);
            }
            if (!dbContent.SavingsAccounts.Any())
            {
                dbContent.SavingsAccounts.AddRange(SavingsAccountTestObjects);
            }
            if (!dbContent.Subscriptions.Any())
            {
                dbContent.Subscriptions.AddRange(SubscriptionTestObjects);
            }
            if (!dbContent.ForecastReports.Any())
            {
                dbContent.ForecastReports.AddRange(ForecastReportTestObjects);
            }
            if (!dbContent.Transactions.Any())
            {
                dbContent.Transactions.AddRange(TransactionTestObjects);
            }
            if (!dbContent.TransactionAttachments.Any())
            {
                dbContent.TransactionAttachments.AddRange(TransactionAttachmentTestObjects);
            }
            if (!dbContent.TransactionComments.Any())
            {
                dbContent.TransactionComments.AddRange(TransactionCommentTestObjects);
            }
            if (!dbContent.TransactionTags.Any())
            {
                dbContent.TransactionTags.AddRange(TransactionTagTestObjects);
            }
            if (!dbContent.Users.Any())
            {
                dbContent.Users.AddRange(UserTestObjects);
            }
            if (!dbContent.UsersSettings.Any())
            {
                dbContent.UsersSettings.AddRange(UserSettingsTestObjects);
            }


            dbContent.SaveChanges();
        }

        private static List<Account>? account;
        private static List<ActivityLog>? activityLog;
        private static List<Category>? category;
        private static List<DebtTracker>? debtTracker;
        private static List<ExpenseReport>? expenseReport;
        private static List<MoneyTracking>? moneytracking;
        private static List<FinancialGoalAccount>? financialGoalAccount;
        private static List<IncomeReport>? incomeReport;
        private static List<Notification>? notification;
        private static List<Personalization>? personalization;
        private static List<RecurringTransaction>? recurringTransaction;
        private static List<SavingsAccount>? savingsAccount;
        private static List<Subscription>? subscription;
        private static List<ForecastReport>? forecastReport;
        private static List<Transaction>? transaction;
        private static List<TransactionAttachment>? transactionAttachment;
        private static List<TransactionComment>? transactionComment;
        private static List<TransactionTag>? transactionTag;
        private static List<User>? user;
        private static List<UserSettings>? userSettings;

        private static List<Account> AccountTestObjects
        {
            get
            {
                if (account is null)
                {
                    var list = new Account[]
                    {

                    };

                    account = new List<Account>();

                    foreach (Account item in list)
                    {
                        account.Add(item);
                    }
                }

                return account;
            }
        }
        private static List<ActivityLog> ActivityLogTestObjects
        {
            get
            {
                if (activityLog is null)
                {
                    var list = new ActivityLog[]
                    {

                    };

                    activityLog = new List<ActivityLog>();

                    foreach (ActivityLog item in list)
                    {
                        activityLog.Add(item);
                    }
                }

                return activityLog;
            }
        }
        private static List<Category> CategoryTestObjects
        {
            get
            {
                if (category is null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Продукты", CategoryType = "Expense", UserId = 1},
                        new Category { CategoryName = "Транспорт", CategoryType = "Expense", UserId = 1},
                        new Category { CategoryName = "Работа", CategoryType = "Income", UserId = 1 },
                        new Category { CategoryName = "Пенсия", CategoryType = "Income", UserId = 1 }
                    };

                    category = new List<Category>();

                    foreach (Category item in list)
                    {
                        category.Add(item);
                    }
                }

                return category;
            }
        }
        private static List<DebtTracker> DebtTrackerTestObjects
        {
            get
            {
                if (debtTracker is null)
                {
                    var list = new DebtTracker[]
                    {

                    };

                    debtTracker = new List<DebtTracker>();

                    foreach (DebtTracker item in list)
                    {
                        item.DueDate = item.DueDate.ToUniversalTime();

                        debtTracker.Add(item);
                    }
                }

                return debtTracker;
            }
        }
        private static List<ExpenseReport> ExpenseReportTestObjects
        {
            get
            {
                if (expenseReport is null)
                {
                    var list = new ExpenseReport[]
                    {

                    };

                    expenseReport = new List<ExpenseReport>();

                    foreach (ExpenseReport item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.EndDate = item.EndDate.ToUniversalTime();

                        expenseReport.Add(item);
                    }
                }

                return expenseReport;
            }
        }
        private static List<MoneyTracking> MoneyTrackingTestObjects
        {
            get
            {
                if (moneytracking is null)
                {
                    var list = new MoneyTracking[]
                    {

                    };

                    moneytracking = new List<MoneyTracking>();

                    foreach (MoneyTracking item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.EndDate = item.EndDate.ToUniversalTime();

                        moneytracking.Add(item);
                    }
                }

                return moneytracking;
            }
        }
        private static List<FinancialGoalAccount> FinancialGoalAccountTestObjects
        {
            get
            {
                if (financialGoalAccount is null)
                {
                    var list = new FinancialGoalAccount[]
                    {

                    };

                    financialGoalAccount = new List<FinancialGoalAccount>();

                    foreach (FinancialGoalAccount item in list)
                    {
                        item.TargetDate = item.TargetDate.ToUniversalTime();

                        financialGoalAccount.Add(item);
                    }
                }

                return financialGoalAccount;
            }
        }
        
        private static List<IncomeReport> IncomeReportTestObjects
        {
            get
            {
                if (incomeReport is null)
                {
                    var list = new IncomeReport[]
                    {

                    };

                    incomeReport = new List<IncomeReport>();

                    foreach (IncomeReport item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.EndDate = item.EndDate.ToUniversalTime();

                        incomeReport.Add(item);
                    }
                }

                return incomeReport;
            }
        }
        private static List<Notification> NotificationTestObjects
        {
            get
            {
                if (notification is null)
                {
                    var list = new Notification[]
                    {
                        new Notification { Message = "Don't forget to keep track of your finance", DateSent = DateTime.Now.AddDays(5), UserId = 1}
                    };

                    notification = new List<Notification>();

                    foreach (Notification item in list)
                    {
                        item.DateSent = item.DateSent.ToUniversalTime();

                        notification.Add(item);
                    }
                }

                return notification;
            }
        }
        private static List<Personalization> PersonalizationTestObjects
        {
            get
            {
                if (personalization is null)
                {
                    var list = new Personalization[]
                    {
                        new Personalization { PeriodOfTime = "Month", AccountId = 1, UserId = 1 }
                    };

                    personalization = new List<Personalization>();

                    foreach (Personalization item in list)
                    {
                        personalization.Add(item);
                    }
                }

                return personalization;
            }
        }
        private static List<RecurringTransaction> RecurringTransactionTestObjects
        {
            get
            {
                if (recurringTransaction is null)
                {
                    var list = new RecurringTransaction[]
                    {

                    };

                    recurringTransaction = new List<RecurringTransaction>();

                    foreach (RecurringTransaction item in list)
                    {
                        item.OccurrenceDate = item.OccurrenceDate.ToUniversalTime();

                        recurringTransaction.Add(item);
                    }
                }

                return recurringTransaction;
            }
        }
        private static List<SavingsAccount> SavingsAccountTestObjects
        {
            get
            {
                if (savingsAccount is null)
                {
                    var list = new SavingsAccount[]
                    {
                        new SavingsAccount { Name = "Flat", StartDate = DateTime.Parse("15/04/2025 10:00:00"), EndDate = DateTime.Parse("15/04/2026 10:00:00"), PeriodOfStacking = 12, AmountInvested = 1000, Balance = 1000, Currency = "USD", CompoundInterest = false, RatePercent = 20, UserId = 1}
                    };

                    savingsAccount = new List<SavingsAccount>();

                    foreach (SavingsAccount item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.EndDate = item.EndDate.ToUniversalTime();

                        savingsAccount.Add(item);
                    }
                }

                return savingsAccount;
            }
        }
        private static List<Subscription> SubscriptionTestObjects
        {
            get
            {
                if (subscription is null)
                {
                    var list = new Subscription[]
                    {
                        new Subscription { Name = "Free", Amount = 0, Currency = "USD", StartDate = DateTime.Now, RenevalDate = DateTime.Parse("15/04/2025 15:00:00"), Frequency = "", UserId = 1}
                    };

                    subscription = new List<Subscription>();

                    foreach (Subscription item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.RenevalDate = item.RenevalDate.ToUniversalTime();

                        subscription.Add(item);
                    }
                }

                return subscription;
            }
        }
        private static List<ForecastReport> ForecastReportTestObjects
        {
            get
            {
                if (forecastReport is null)
                {
                    var list = new ForecastReport[]
                    {
                    };

                    forecastReport = new List<ForecastReport>();

                    foreach (ForecastReport item in list)
                    {
                        item.StartDate = item.StartDate.ToUniversalTime();
                        item.EndDate = item.EndDate.ToUniversalTime();

                        forecastReport.Add(item);
                    }
                }

                return forecastReport;
            }
        }
        private static List<Transaction> TransactionTestObjects
        {
            get
            {
                if (transaction is null)
                {
                    var list = new Transaction[]
                    {
                      
                    };

                    transaction = new List<Transaction>();

                    foreach (Transaction item in list)
                    {
                        item.Date = item.Date.ToUniversalTime();

                        transaction.Add(item);
                    }
                }

                return transaction;
            }
        }
        private static List<TransactionAttachment> TransactionAttachmentTestObjects
        {
            get
            {
                if (transactionAttachment is null)
                {
                    var list = new TransactionAttachment[]
                    {
                        
                    };

                    transactionAttachment = new List<TransactionAttachment>();

                    foreach (TransactionAttachment item in list)
                    {
                        transactionAttachment.Add(item);
                    }
                }

                return transactionAttachment;
            }
        }
        private static List<TransactionComment> TransactionCommentTestObjects
        {
            get
            {
                if (transactionComment is null)
                {
                    var list = new TransactionComment[]
                    {
                       
                    };

                    transactionComment = new List<TransactionComment>();

                    foreach (TransactionComment item in list)
                    {
                        transactionComment.Add(item);
                    }
                }

                return transactionComment;
            }
        }
        private static List<TransactionTag> TransactionTagTestObjects
        {
            get
            {
                if (transactionTag is null)
                {
                    var list = new TransactionTag[]
                    {
                       
                    };

                    transactionTag = new List<TransactionTag>();

                    foreach (TransactionTag item in list)
                    {
                        transactionTag.Add(item);
                    }
                }

                return transactionTag;
            }
        }
        private static List<User> UserTestObjects
        {
            get
            {
                if (user is null)
                {
                    var list = new User[]
                    {

                    };

                    user = new List<User>();

                    foreach (User item in list)
                    {
                        item.CreatedAt = item.CreatedAt.ToUniversalTime();

                        user.Add(item);
                    }
                }

                return user;
            }
        }
        private static List<UserSettings> UserSettingsTestObjects
        {
            get
            {
                if (userSettings is null)
                {
                    var list = new UserSettings[]
                    {
                        new UserSettings { Theme = "Light", NotificationPreferences = true, UserId = 1 }
                    };

                    userSettings = new List<UserSettings>();

                    foreach (UserSettings item in list)
                    {
                        userSettings.Add(item);
                    }
                }

                return userSettings;
            }
        }
    }
}
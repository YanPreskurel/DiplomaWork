using FinLit.Data;
using FinLit.Data.Interfaces;
using FinLit.Data.Repository;
using FinLit.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContent>(options => options.UseNpgsql(connection));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAccounts, AccountRepository>();
builder.Services.AddTransient<ICategories, CategoryRepository>();
builder.Services.AddTransient<IMoneyTrackings, MoneyTrackingRepository>();
builder.Services.AddTransient<ITransactions, TransactionRepository>();
builder.Services.AddTransient<ITransactionAttachments, TransactionAttachmentRepository>();
builder.Services.AddTransient<ITransactionComments, TransactionCommentRepository>();
builder.Services.AddTransient<ITransactionTags, TransactionTagRepository>();
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IIncomeReports, IncomeReportRepository>();
builder.Services.AddTransient<IExpenseReports, ExpenseReportRepository>();
builder.Services.AddTransient<IForecastReports, ForecastReportRepository>();
builder.Services.AddTransient<IRecurringTransactions, RecurringTransactionRepository>();
builder.Services.AddTransient<IDebtTrackers, DebtTrackerRepository>();
builder.Services.AddTransient<IFinancialGoalAccounts, FinancialGoalAccountRepository>();
builder.Services.AddTransient<IUsersSettings, UserSettingsRepository>();
builder.Services.AddTransient<INotifications, NotificationRepository>();
builder.Services.AddTransient<IPersonalizations, PersonalizationRepository>();


builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<MoneyTrackingService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<RecurringTransactionService>();
builder.Services.AddScoped<FinancialGoalAccountService>();
builder.Services.AddHostedService<RecurringTransactionWorker>(); // фоновая задача 


builder.Services.AddSession();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=AuthentificationView}/{id?}");


using (var scope = app.Services.CreateScope())
{
    DbContent dbContent = scope.ServiceProvider.GetRequiredService<DbContent>();
    DbTestObjects.Initial(dbContent);
}

app.Run();

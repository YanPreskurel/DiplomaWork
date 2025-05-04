using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccounts accountsRepository;
        private readonly IMoneyTrackings moneyTrackingsRepository;
        private readonly ITransactions transactionsRepository;
        private readonly ICategories categoriesRepository;
        public HomeController(IAccounts accountsRepository, IMoneyTrackings moneyTrackingsRepository, ITransactions transactionsRepository, ICategories categoriesRepository)
        {
            this.accountsRepository = accountsRepository;
            this.moneyTrackingsRepository = moneyTrackingsRepository;
            this.transactionsRepository = transactionsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("AuthentificationView", "User");
            }

            var model = new IndexViewModel
            {
                AccountMoneyTracking = new AccountMoneyTrackingViewModel
                {
                    Accounts = await accountsRepository.GetAllAsync(),
                    MoneyTrackings = await moneyTrackingsRepository.GetAllAsync()
                },
                TransactionFormViewModel = new TransactionFormViewModel 
                {
                    Categories = await categoriesRepository.GetAllAsync()
                }
            };

            return View(model);  // Передаем модель в представление
        }
    }
}

using FinLit.Data.Enums;
using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinLit.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccounts accountsRepository;
        private readonly IMoneyTrackings moneyTrackingsRepository;
        public AccountController(IAccounts accountsRepository, IMoneyTrackings moneyTrackingsRepository)
        {
            this.accountsRepository = accountsRepository;
            this.moneyTrackingsRepository = moneyTrackingsRepository;
        }

        public async Task<PartialViewResult> AccountView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var model = new AccountMoneyTrackingViewModel
            {
                Accounts = (await accountsRepository.GetAllAsync()).Where(a => a.UserId == userId),
                MoneyTrackings = await moneyTrackingsRepository.GetAllAsync()
            };

            return PartialView(model);
        }

        [HttpGet]
        public IActionResult AddAccountView()
        {
            ViewBag.Currencies = Enum.GetValues(typeof(CurrencyType))
                     .Cast<CurrencyType>()
                     .Select(c => c.ToString())
                     .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            if (ModelState.IsValid)
            {
                var newAccount = new Account
                {
                    Name = account.Name,
                    Balance = account.Balance,
                    Currency = account.Currency,
                    UserId = (int)userId
                };

                await accountsRepository.AddAsync(newAccount);
                await moneyTrackingsRepository.AddAsync(new MoneyTracking { AccountId = newAccount.Id });

                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult SelectAccount(int accountId)
        {
            HttpContext.Session.SetInt32("SelectedAccountId", accountId);
            return RedirectToAction("Index", "Home");
        }
    }
}


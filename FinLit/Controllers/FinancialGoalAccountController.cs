using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.Services;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace FinLit.Controllers
{
    public class FinancialGoalAccountController : Controller
    {
        private readonly IFinancialGoalAccounts financialGoalAccountsRepository;
        private readonly FinancialGoalAccountService financialGoalAccountService;
        public FinancialGoalAccountController(IFinancialGoalAccounts financialGoalAccountsRepository, FinancialGoalAccountService financialGoalAccountService)
        {
            this.financialGoalAccountsRepository = financialGoalAccountsRepository;
            this.financialGoalAccountService = financialGoalAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> FinancialGoalAccountView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            var financialGoalAccounts = (await financialGoalAccountsRepository.GetAllAsync()).Where(c => c.UserId == userId);

            var model = new FinancialGoalAccountFormViewModel()
            {
                FinancialGoalAccounts = financialGoalAccounts
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddFinancialGoalAccount(FinancialGoalAccountFormViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            if(!ModelState.IsValid)
            {
                var financialGoalAccounts = (await financialGoalAccountsRepository.GetAllAsync()).Where(c => c.UserId == userId);
                model.FinancialGoalAccounts = financialGoalAccounts;

                return View("FinancialGoalAccountView", model);
            }

            var newFinancialGoalAccount = new FinancialGoalAccount
            { 
                Name = model.Name ?? "",
                GoalAmount = model.GoalAmount,
                Balance = 0,
                Currency = model.Currency.ToString(),
                TargetDate = model.TargetDate.ToUniversalTime(),
                UserId = (int)userId
            };

            await financialGoalAccountsRepository.AddAsync(newFinancialGoalAccount);

            return RedirectToAction("FinancialGoalAccountView");
        }

        [HttpPost]
        public async Task<IActionResult> AddBalanceToGoal(decimal amount, int financialGoalAccountId)
        {
            await financialGoalAccountService.AddTransactionToFinancialGoalAccountAsync(amount, financialGoalAccountId);
            return RedirectToAction("FinancialGoalAccountView");
        }

    }
}

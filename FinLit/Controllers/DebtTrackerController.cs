using FinLit.Data.Enums;
using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class DebtTrackerController : BaseController
    {
        private readonly IDebtTrackers debtTrackersRepository;

        public DebtTrackerController(IDebtTrackers debtTrackersRepository)
        {
            this.debtTrackersRepository = debtTrackersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> DebtTrackerView()
        {
            var userId = GetUserIdOrRedirect();

            var debtTrackers = (await debtTrackersRepository.GetAllAsync()).Where(dt => dt.UserId == userId);

            var model = new DebtTrackerFormViewModel
            {
                DebtTrackers = debtTrackers
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddDebtTracker(DebtTrackerFormViewModel model)
        {
            var userId = GetUserIdOrRedirect();

            if (!ModelState.IsValid)
            {
                var debtTrackers = (await debtTrackersRepository.GetAllAsync()).Where(dt => dt.UserId == userId);
                model.DebtTrackers = debtTrackers;

                return View("DebtTrackerView", model);
            }

            var newDebtTracker = new DebtTracker
            {
                Amount = model.Amount,
                Currency = model.Currency?.ToString() ?? "",
                Debtor = model.Debtor ?? "",
                DebtType = model.DebtType ?? "",
                DueDate = model.DueDate.ToUniversalTime(),
                Status = model.Status,
                UserId = userId
            };

            return RedirectToAction("DebtTrackerView");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDebtTracker(int id)
        {
            var userId = GetUserIdOrRedirect();

            var debtTracker = await debtTrackersRepository.GetByIdAsync(id);

            if (debtTracker.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            await debtTrackersRepository.DeleteAsync(id);

            return RedirectToAction("DebtTrackerView");
        }

        [HttpGet]
        public async Task<IActionResult> EditDebtTracker(int id)
        {
            var userId = GetUserIdOrRedirect();

            var debtTracker = await debtTrackersRepository.GetByIdAsync(id);

            if (debtTracker.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            var model = new DebtTrackerFormViewModel
            {
                Id = debtTracker.Id,
                Amount = debtTracker.Amount,
                Currency = Enum.TryParse<CurrencyType>(debtTracker.Currency, out var currency) ? currency : null,
                Debtor = debtTracker.Debtor,
                DebtType = debtTracker.DebtType,
                DueDate = debtTracker.DueDate.ToLocalTime(),
                Status = debtTracker.Status
            };

            return View("EditDebtTrackerView", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditDebtTracker(DebtTrackerFormViewModel model)
        {
            var userId = GetUserIdOrRedirect();

            if (!ModelState.IsValid)
                return View("EditDebtTrackerView", model);

            var debtTracker = await debtTrackersRepository.GetByIdAsync(model.Id);
            if (debtTracker.UserId != userId)
                return RedirectToAction("AuthentificationView", "User");

            debtTracker.Amount = model.Amount;
            debtTracker.Currency = model.Currency?.ToString() ?? "";
            debtTracker.Debtor = model.Debtor ?? "";
            debtTracker.DebtType = model.DebtType ?? "";
            debtTracker.DueDate = model.DueDate.ToUniversalTime();
            debtTracker.Status = model.Status;

            await debtTrackersRepository.UpdateAsync(debtTracker);

            return RedirectToAction("DebtTrackerView");
        }

    }
}

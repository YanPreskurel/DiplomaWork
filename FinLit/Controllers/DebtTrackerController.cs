using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class DebtTrackerController : Controller
    {
        private readonly IDebtTrackers debtTrackersRepository;

        public DebtTrackerController(IDebtTrackers debtTrackersRepository)
        {
            this.debtTrackersRepository = debtTrackersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> DebtTrackerView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("AuthentificationView", "User");
            }            

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
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("AuthentificationView", "User");
            }

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
                UserId = (int)userId           
            };

            return RedirectToAction("DebtTrackerView");
        }
    }
}

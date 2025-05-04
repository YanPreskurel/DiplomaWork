using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinLit.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUsersSettings usersSettingsRepository;
        private readonly IPersonalizations personalizationsRepository;
        private readonly IAccounts accountsRepository;

        public SettingsController(
            IUsersSettings usersSettingsRepository,
            IPersonalizations personalizationsRepository,
            IAccounts accountsRepository)
        {
            this.usersSettingsRepository = usersSettingsRepository;
            this.personalizationsRepository = personalizationsRepository;
            this.accountsRepository = accountsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SettingsView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            var accounts = (await accountsRepository.GetAllAsync())
                .Where(a => a.UserId == userId)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .ToList();

            var personalization = (await personalizationsRepository.GetAllAsync())
                .FirstOrDefault(p => p.UserId == userId);
            var userSettings = (await usersSettingsRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserId == userId);

            var model = new SettingsViewModel
            {
                Personalization = personalization,
                UserSettings = userSettings,
                Accounts = accounts
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonalization(SettingsViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            if (model.Personalization != null)
            {
                model.Personalization.UserId = userId.Value;
                await personalizationsRepository.UpdateAsync(model.Personalization);
            }

            return RedirectToAction("SettingsView");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserSettings(SettingsViewModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            if (model.UserSettings != null)
            {
                model.UserSettings.UserId = userId.Value;
                await usersSettingsRepository.UpdateAsync(model.UserSettings);
            }

            return RedirectToAction("SettingsView");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SettingsView(SettingsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Обновляем настройки пользователя
            if (model.UserSettings != null)
                await usersSettingsRepository.UpdateAsync(model.UserSettings);

            if (model.Personalization != null)
                await personalizationsRepository.UpdateAsync(model.Personalization);

            // Перезагружаем список аккаунтов, если ты используешь SelectListItem
            var accounts = await accountsRepository.GetAllAsync();
            model.Accounts = accounts.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            ViewBag.Success = "Настройки успешно сохранены!";
            return View(model);
        }

    }
}

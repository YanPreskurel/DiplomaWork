using FinLit.Data.Enums;
using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Data.Repository;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace FinLit.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers usersRepository;

        private readonly IAccounts accountsRepository;
        private readonly ICategories categoriesRepository;
        private readonly IPersonalizations personalizationsRepository;
        private readonly IUsersSettings usersSettingsRepository;
        public UserController(IUsers usersRepository, IAccounts accountsRepository, ICategories categoriesRepository, IPersonalizations personalizationsRepository, IUsersSettings usersSettingsRepository)
        {
            this.usersRepository = usersRepository;
            this.accountsRepository = accountsRepository;
            this.categoriesRepository = categoriesRepository;
            this.personalizationsRepository = personalizationsRepository;
            this.usersSettingsRepository = usersSettingsRepository;
        }

        [HttpGet]
        public IActionResult AuthentificationView()
        {
            return View(new AuthentificationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthentificationViewModel model)
        {
            ModelState.Clear();
            TryValidateModel(model.Login);

            if (!ModelState.IsValid)
                return View("AuthentificationView", model);

            var allUsers = await usersRepository.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Email == model.Login.Email);

            if (user == null || user.PasswordHash != HashPassword(model.Login.Password))
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View("AuthentificationView", model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthentificationViewModel model)
        {
            ModelState.Clear();
            TryValidateModel(model.Register);

            if (!ModelState.IsValid)
                return View("AuthentificationView", model);

            var allUsers = await usersRepository.GetAllAsync();
            if (allUsers.Any(u => u.Email == model.Register.Email))
            {
                ModelState.AddModelError("", "Пользователь с таким email уже существует");
                return View("AuthentificationView", model);
            }

            var newUser = new User
            {
                Name = model.Register.Name,
                Email = model.Register.Email,
                PasswordHash = HashPassword(model.Register.Password),
                CreatedAt = DateTime.UtcNow
            };

            await usersRepository.AddAsync(newUser);
            HttpContext.Session.SetInt32("UserId", newUser.Id);

            // инициализация дефолтных сущностей для нового зарегестрированного пользователя - вынести в отдельный сервис с передачей UserId
            var newAccount = new Account
            {
                Balance = 0,
                Currency = CurrencyType.BYN.ToString(),
                Name = "Основной",
                UserId = newUser.Id
            };

            await accountsRepository.AddAsync(newAccount);
            await categoriesRepository.AddAsync(new Category { CategoryName = "Другое", CategoryType = "Expense", CategoryImage = "", UserId = newUser.Id });
            await categoriesRepository.AddAsync(new Category { CategoryName = "Другое", CategoryType = "Income", CategoryImage = "", UserId = newUser.Id });
            await personalizationsRepository.AddAsync(new Personalization { AccountId = newAccount.Id, PeriodOfTime = "Month", UserId = newUser.Id });
            await usersSettingsRepository.AddAsync(new UserSettings { NotificationPreferences = false, Theme = "Default", UserId = newUser.Id });
            //----------------------------------------------------------------------------------------------------------------

            return RedirectToAction("Index", "Home");
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
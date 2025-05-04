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
        IUsers usersRepository;
        public UserController(IUsers usersRepository)
        {
            this.usersRepository = usersRepository;
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
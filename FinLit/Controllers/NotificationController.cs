using FinLit.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinLit.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotifications notificationsRepository;
        public NotificationController(INotifications notificationsRepository)
        {
            this.notificationsRepository = notificationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> NotificationView()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            var notifications = (await notificationsRepository.GetAllAsync()).Where(n => n.UserId == userId);

            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> ClearNotifications()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("AuthentificationView", "User");

            await notificationsRepository.DeleteAllAsync(userId.Value);
            return RedirectToAction("NotificationView");
        }

    }
}

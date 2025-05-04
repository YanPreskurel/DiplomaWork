using FinLit.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinLit.ViewModels
{
    public class SettingsViewModel
    {
        public Personalization? Personalization { get; set; }
        public UserSettings? UserSettings { get; set; }

        public List<SelectListItem> Accounts { get; set; } = new();
    }
}

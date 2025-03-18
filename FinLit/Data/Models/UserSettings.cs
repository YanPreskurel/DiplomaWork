namespace FinLit.Data.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string? Theme { get; set; }
        public string? NotificationPreferences { get; set; }
        public int UserId { get; set; }
    }
}

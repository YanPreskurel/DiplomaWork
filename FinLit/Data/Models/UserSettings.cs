using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class UserSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Theme { get; set; } // dark light default 
        public bool NotificationPreferences { get; set; } // true на уведомления 
        public int UserId { get; set; }
    }
}

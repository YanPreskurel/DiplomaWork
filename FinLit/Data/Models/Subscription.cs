using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; } // Free, Premium
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RenevalDate { get; set; }
        public required string Frequency { get; set; } // месячная или годовая 
        public int UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class MoneyTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToUniversalTime();
        public DateTime EndDate { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1).ToUniversalTime();
        public decimal Amount { get; set; } = 0;
        public int AccountId { get; set; }

    }
}

using FinLit.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class FinancialGoalAccount : IAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal Balance { get; set; } // накопленная сумма 
        public required string Currency { get; set; }
        public DateTime TargetDate { get; set; } // дата накопления 
        public int UserId { get; set; }
    }
}

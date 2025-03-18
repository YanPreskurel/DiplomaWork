using FinLit.Data.Interfaces;

namespace FinLit.Data.Models
{
    public class FinancialGoalAccount : IAccount
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal Balance { get; set; } // накопленная сумма 
        public DateTime TargetDate { get; set; } // дата накопления 
        public required string Currency { get; set; }
        public int UserId { get; set; }
    }
}

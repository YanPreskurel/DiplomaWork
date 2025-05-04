using FinLit.Data.Enums;
using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class FinancialGoalAccountFormViewModel
    {
        public string? Name { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal Balance { get; set; } // накопленная сумма 
        public CurrencyType Currency { get; set; }
        public DateTime TargetDate { get; set; }

        public IEnumerable<FinancialGoalAccount> FinancialGoalAccounts { get; set;} = new List<FinancialGoalAccount>();
    }
}

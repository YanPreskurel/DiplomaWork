using FinLit.Data.Interfaces;

namespace FinLit.Data.Models
{
    public class SavingsAccount : IAccount
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PeriodOfStacking { get; set; } // месяц - пол года - 2
        public decimal AmountInvested { get; set; } // сколько изначальных сбережений
        public decimal Balance { get; set; } // текущий баланс
        public required string Currency { get; set; }
        public bool CompoundInterest { get; set; } // сложные проценты
        public float RatePercent { get; set; } // процент ставки
        public int UserId { get; set; }
    }
}

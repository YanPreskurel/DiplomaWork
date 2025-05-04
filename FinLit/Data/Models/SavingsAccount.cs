using FinLit.Data.Models.Interfaces;

namespace FinLit.Data.Models
{
    public class SavingsAccount : IAccount
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint PeriodOfStacking { get; set; } // сколько месяцев хранить
        public decimal AmountInvested { get; set; } // сколько изначальных сбережений
        public decimal Balance { get; set; } // текущий баланс
        public required string Currency { get; set; }
        public bool CompoundInterest { get; set; } // сложные проценты
        public float RatePercent { get; set; } // процент годовой ставки  / 12 за месяц
        public int UserId { get; set; }
    }
}

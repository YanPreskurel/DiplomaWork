namespace FinLit.Data.Models
{
    public class ExpenseTracking
    {
        public int Id { get; set; }
        public DateTime PeriodOfTracking { get; set; } // от и до мб 2 переменные 
        public decimal AmountSpent { get; set; }
        public int AccountId { get; set; }

    }
}

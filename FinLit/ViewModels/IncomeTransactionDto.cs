namespace FinLit.ViewModels
{
    public class IncomeTransactionDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}

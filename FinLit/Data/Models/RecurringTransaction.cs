namespace FinLit.Data.Models
{
    public class RecurringTransaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public required string Frequency { get; set; }
        public DateTime OccurrenceDate { get; set; }
        public string? Description { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}

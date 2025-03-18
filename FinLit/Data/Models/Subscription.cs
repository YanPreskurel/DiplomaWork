namespace FinLit.Data.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RenevalDate { get; set; }
        public required string Frequency { get; set; }
        public int UserId { get; set; }
    }
}

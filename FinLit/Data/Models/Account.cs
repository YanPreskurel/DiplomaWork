namespace FinLit.Data.Models
{
    public class Account
    {
        public int Id { get; set; }
        public required string AccountName { get; set; }
        public required string AccountType { get; set; }
        public decimal Balance { get; set; }
        public required string Currency { get; set; }
        public int UserId { get; set; }
    }
}

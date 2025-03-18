namespace FinLit.Data.Models
{
    public class TransactionTag
    {
        public int Id { get; set; }
        public required string TagName { get; set; }
        public int TransactionId { get; set; }
    }
}

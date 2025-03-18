namespace FinLit.Data.Models
{
    public class TransactionAttachment
    {
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required string FilePath { get; set; } // mb link 
        public int TransactionId { get; set; }
    }
}

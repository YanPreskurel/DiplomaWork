namespace FinLit.Data.Models
{
    public class TransactionComment
    {
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int TransactionId { get; set; }
        public int UserId { get; set; }
    }
}

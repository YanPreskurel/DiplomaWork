namespace FinLit.Data.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? IPAddress { get; set; }
        public int UserId { get; set; }
    }
}

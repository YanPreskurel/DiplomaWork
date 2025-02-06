namespace FinLit.Data.Models
{
    public class Personalization
    {
        public int Id { get; set; }
        public required string PeriodOfTime { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
    }
}

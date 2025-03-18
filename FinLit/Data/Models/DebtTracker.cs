using Microsoft.VisualBasic;

namespace FinLit.Data.Models
{
    public class DebtTracker
    {
        public int Id { get; set; }
        public required string DebtType { get; set; } // входящий или исходящий
        public decimal Amount { get; set; }
        public required string Debtor { get; set; } // имя должника
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } = false;
        public int UserId { get; set; }
    }
}

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class DebtTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string DebtType { get; set; } // Incoming or Outgoing
        public decimal Amount { get; set; }
        public required string Currency { get; set; } // Dollar or Byn текущего счета 
        public required string Debtor { get; set; } // имя должника
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } = false;
        public int UserId { get; set; }
    }
}

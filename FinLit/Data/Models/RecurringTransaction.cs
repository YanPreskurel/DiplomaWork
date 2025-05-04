using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class RecurringTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Сумма не может быть отрицательной")]
        public decimal Amount { get; set; }

        public required string Frequency { get; set; } // day month year
        public DateTime OccurrenceDate { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int TransactionAttachmentId { get; set; }
        public int TransactionCommentId { get; set; }
        public int TransactionTagId { get; set; }

        public Category Category { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public TransactionAttachment TransactionAttachment { get; set; } = null!;
        public TransactionComment TransactionComment { get; set; } = null!;
        public TransactionTag TransactionTag { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class TransactionAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FileName { get; set; } 
        public string? FilePath { get; set; } // mb URL
        public int UserId { get; set; }
    }
}

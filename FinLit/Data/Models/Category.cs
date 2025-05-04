using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryType { get; set; } // доход или расход (Income or Expense)
        public string? CategoryImage { get; set; }
        public int UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class Personalization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string PeriodOfTime { get; set; } //  Показывать по умолчанию day month year
        public int AccountId { get; set; } // id счета по умолчанию
        public int UserId { get; set; }
    }
}

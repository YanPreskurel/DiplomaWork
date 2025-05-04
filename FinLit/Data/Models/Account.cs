using FinLit.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class Account : IAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public required string Currency { get; set; }
        public int UserId { get; set; }
    }
}

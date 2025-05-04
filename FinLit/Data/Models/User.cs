using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinLit.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

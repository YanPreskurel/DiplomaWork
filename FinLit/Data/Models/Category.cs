namespace FinLit.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public int UserId { get; set; }
    }
}

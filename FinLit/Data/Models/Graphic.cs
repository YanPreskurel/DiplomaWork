namespace FinLit.Data.Models
{
    public class Graphic
    {
        public int Id { get; set; }
        public required string GraphicType { get; set; }
        public int UserId { get; set; }
    }
}

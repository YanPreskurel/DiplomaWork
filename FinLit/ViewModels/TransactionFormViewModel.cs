using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class TransactionFormViewModel
    {
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string? CommentText { get; set; }
        public string? TagName { get; set; }
        public string? AttachmentUrl { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

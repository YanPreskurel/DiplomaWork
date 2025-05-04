using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class RecurringTransactionFormViewModel
    {
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string? CommentText { get; set; }
        public string? TagName { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? Frequency { get; set; } // day month year
        public DateTime OccurrenceDate { get; set; } // data nastupleniya
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class TransactionCategoryViewModel
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int TransactionAttachmentId { get; set; }
        public int TransactionCommentId { get; set; }
        public int TransactionTagId { get; set; }

        public string? CommentText { get; set; }
        public string? TagName { get; set; }
        public string? AttachmentUrl { get; set; }




        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
        public required IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public required IEnumerable<Account> Accounts { get; set; } = new List<Account>();
        public string OperationType { get; set; } = "All";

        public DateTime StartDate { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1).AddSeconds(-1);

        public int? SelectedCategoryId { get; set; }
    }
}

using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class TransactionCategoryViewModel
    {
        public required IEnumerable<Transaction> Transactions { get; set; }
        public required IEnumerable<Category> Categories { get; set; }
        public required IEnumerable<Account> Accounts { get; set; }
        public string OperationType { get; set; } = "All";

        public DateTime StartDate { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1).AddSeconds(-1);

        public int? SelectedCategoryId { get; set; }
    }
}

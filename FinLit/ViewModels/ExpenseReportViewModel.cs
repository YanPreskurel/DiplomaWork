using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class ExpenseReportViewModel
    {
        public ExpenseReport ExpenseReport { get; set; } = new() { ReportType = "" };
        public List<ExpenseTransactionDto> Transactions { get; set; } = new();
    }

}

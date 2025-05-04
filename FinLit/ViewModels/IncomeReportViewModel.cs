using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class IncomeReportViewModel
    {
        public IncomeReport IncomeReport { get; set; } = new() { ReportType = "" };
        public List<IncomeTransactionDto> Transactions { get; set; } = new();
    }

}

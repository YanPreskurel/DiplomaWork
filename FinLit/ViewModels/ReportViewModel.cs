using FinLit.Data.Models;

namespace FinLit.ViewModels
{
    public class ReportViewModel
    {
        public IEnumerable<IncomeReportViewModel>? IncomeReportViewModels { get; set; }
        public IEnumerable<ExpenseReportViewModel>? ExpenseReportViewModels { get; set; }
        public ForecastReport? ForecastReport { get; set; }
    }
}
